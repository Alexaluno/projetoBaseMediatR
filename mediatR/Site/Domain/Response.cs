using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Domain
{
    public class Response
    {
               
        public static Response Ok = new Response();

        private List<ValidationFailure> _validations = new List<ValidationFailure>();
        public object Data { get; set; }

        public bool HasValidations { get; set; }

        public IEnumerable<ValidationFailure> Validations => this._validations;

        public bool HasError { get; set; }

        public ValidationFailure Error { get; set; }

        public Response() {
            this.Data = null;
            this.HasError = false;
            this.HasValidations = false;
        }

        public Response(object data)
        {
            this.Data = data;
            this.HasError = false;
            this.HasValidations = false;
        }

        public Response(Exception ex) {
            this.Error = new ValidationFailure("$Error", ex.Message) { ErrorCode = "500" };
            this.HasError = true;
            this.HasValidations = false;
        }
        public Response(IEnumerable<ValidationFailure> validations) {
            this._validations = validations.ToList();
            this.HasError = false;
            this.HasValidations = true;
        }

        public Response(ValidationFailure validation):this(new[] { validation}) { }

        public Response(string propretyName,string errorMessage):this(new ValidationFailure(propretyName, errorMessage))
        {

        }

    }

}
