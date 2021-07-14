/* 
 * DealersAndVehicles
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// DatasetIdResponse
    /// </summary>
    [DataContract]
    public partial class DatasetIdResponse :  IEquatable<DatasetIdResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatasetIdResponse" /> class.
        /// </summary>
        /// <param name="datasetId">datasetId.</param>
        public DatasetIdResponse(string datasetId = default(string))
        {
            this.DatasetId = datasetId;
        }
        
        /// <summary>
        /// Gets or Sets DatasetId
        /// </summary>
        [DataMember(Name="datasetId", EmitDefaultValue=false)]
        public string DatasetId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DatasetIdResponse {\n");
            sb.Append("  DatasetId: ").Append(DatasetId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as DatasetIdResponse);
        }

        /// <summary>
        /// Returns true if DatasetIdResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of DatasetIdResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DatasetIdResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DatasetId == input.DatasetId ||
                    (this.DatasetId != null &&
                    this.DatasetId.Equals(input.DatasetId))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.DatasetId != null)
                    hashCode = hashCode * 59 + this.DatasetId.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}