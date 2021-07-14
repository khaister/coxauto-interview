using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Api;

namespace BLL.Services
{
    internal class AnswerSubmissionService : IAnswerSubmissionService
    {
        private readonly IDataSetApi _datasetService;
        private readonly IDealersApi _dealdersService;
        private readonly IVehiclesApi _vehiclesService;

        public AnswerSubmissionService(IDataSetApi datasetService, IDealersApi dealersService, IVehiclesApi vehiclesService)
        {
            _datasetService = datasetService;
            _dealdersService = dealersService;
            _vehiclesService = vehiclesService;
        }

        public async Task<IO.Swagger.Model.AnswerResponse> SubmitAsync()
        {
            var datasetId = await GetDatasetIdAsync().ConfigureAwait(false);

            var vehicles = await GetVehiclesByDealerAsync(datasetId).ConfigureAwait(false);
            if (vehicles == null || !vehicles.Any())
                return null;

            var tasks = vehicles.Keys.Select(dealerId => _dealdersService.GetDealerAsync(datasetId, dealerId));
            await Task.WhenAll(tasks).ConfigureAwait(false);

            var dealers = new List<IO.Swagger.Model.DealerAnswer>();
            foreach (var task in tasks)
            {
                var dealer = await task;
                if (dealer == null)
                    continue;

                dealers.Add(new IO.Swagger.Model.DealerAnswer
                {
                    DealerId = dealer.DealerId,
                    Name = dealer.Name,
                    Vehicles = vehicles[dealer.DealerId.Value]
                });
            }

            var answer = new IO.Swagger.Model.Answer
            {
                Dealers = dealers
            };

            return await _datasetService.PostAnswerAsync(datasetId, answer).ConfigureAwait(false);
        }

        private async Task<string> GetDatasetIdAsync()
        {
            var resp = await _datasetService.GetDataSetIdAsync().ConfigureAwait(false);
            if (resp == null || string.IsNullOrWhiteSpace(resp.DatasetId))
                throw new Exception("Remote service does not return a valid DatasetId");

            return resp.DatasetId;
        }

        private async Task<Dictionary<int, List<IO.Swagger.Model.VehicleAnswer>>> GetVehiclesByDealerAsync(string datasetId)
        {
            var vehicleIds = await GetVehicleIdsAsync(datasetId).ConfigureAwait(false);
            if (vehicleIds == null || !vehicleIds.Any())
                return null;

            var vehicles = new Dictionary<int, List<IO.Swagger.Model.VehicleAnswer>>();

            var tasks = vehicleIds.Select(id => _vehiclesService.GetVehicleAsync(datasetId, id));
            await Task.WhenAll(tasks).ConfigureAwait(false);

            foreach (var task in tasks)
            {
                var vehicle = await task;
                var dealerId = vehicle.DealerId;
                if (!dealerId.HasValue)
                    continue;

                if (!vehicles.ContainsKey(dealerId.Value))
                {
                    vehicles.Add(dealerId.Value, new List<IO.Swagger.Model.VehicleAnswer>
                    {
                        new IO.Swagger.Model.VehicleAnswer
                        {
                            Make = vehicle.Make,
                            Model = vehicle.Model,
                            Year = vehicle.Year,
                            VehicleId = vehicle.VehicleId
                        }
                    });
                    continue;
                }

                if (vehicles[dealerId.Value] == null)
                    vehicles[dealerId.Value] = new List<IO.Swagger.Model.VehicleAnswer>();

                vehicles[dealerId.Value].Add(new IO.Swagger.Model.VehicleAnswer
                {
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    VehicleId = vehicle.VehicleId
                });
            }

            return vehicles;
        }

        private async Task<List<int?>> GetVehicleIdsAsync(string datasetId)
        {
            var resp = await _vehiclesService.GetIdsAsync(datasetId).ConfigureAwait(false);
            return resp?.VehicleIds;
        }
    }
}
