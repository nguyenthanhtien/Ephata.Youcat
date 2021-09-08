using NetEscapades.Configuration.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ephata.YouCat.WebAPI.Models
{
    public class ApplicationSettings : IValidatable
    {
        public string ElasticUrl { get; set; }
        public IEnumerable<string> Indices { get; set; }

        public void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }
    }
}
