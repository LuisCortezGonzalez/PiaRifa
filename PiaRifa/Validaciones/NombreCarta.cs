using System.ComponentModel.DataAnnotations;

namespace WebApiRifa.Validaciones
{
    public class NombreCarta : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var car = value.ToString()[0].ToString();
            if (car != car.ToUpper())
            {
                return new ValidationResult("El nombre empieza en mayusculas");
            }

            var elementos = value.ToString().Split(' ');

            if (!(elementos[0].Equals("Las") || elementos[0].Equals("La") || elementos[0].Equals("El")))
            {
                return new ValidationResult("El nombre no cuenta con el pronombre correcto");
            }

            switch (elementos[1])
            {
                case "gallo":
                case "diablo":
                case "dama":
                case "catrin":
                case "paraguas":
                case "sirena":
                case "escalera":
                case "botella":
                case "barril":
                case "arbol":
                case "melon":
                case "valiente":
                case "gorrito":
                case "muerte":
                case "pera":
                case "bandera":
                case "bandolon":
                case "violoncello":
                case "garza":
                case "pajaro":
                case "mano":
                case "bota":
                case "luna":
                case "cotorro":
                case "borracho":
                case "negrito":
                case "corazon":
                case "sandia":
                case "tambor":
                case "camaron":
                case "jaras":
                case "musico":
                case "araña":
                case "soldado":
                case "estrella":
                case "cazo":
                case "venado":
                case "mundo":
                case "apache":
                case "nopal":
                case "alacran":
                case "rosa":
                case "calavera":
                case "campana":
                case "cantarito":
                case "sol":
                case "corona":
                case "chalupa":
                case "pino":
                case "pescado":
                case "palma":
                case "maceta":
                case "arpa":
                case "rana":
                    break;
                default:
                    return new ValidationResult("El nombre no se encuentra dentro de los registrados en la loteria mexicana");

            }
            return ValidationResult.Success;
        }
    }
}