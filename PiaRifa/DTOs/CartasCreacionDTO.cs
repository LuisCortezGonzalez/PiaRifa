using WebApiRifa.Validaciones;
using System.ComponentModel.DataAnnotations;
using WebApiRifa.Entidades;

namespace WebApiRifa.DTOs
{
    public class CartasCreacionDTO: IValidatableObject
    {
        [Required]
        [NombreCarta]
        public string Nombre { get; set; }

        [Required]
        [NumeroCarta]
        public int numero { get; set; }

        public List<RifaParticipante> RifaParticipantes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre) && numero != 0)
            {
                switch (Nombre)
                {
                    case "El gallo":
                        if (numero != 1)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El diablo":
                        if (numero != 2)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La dama":
                        if (numero != 3)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El catrin":
                        if (numero != 4)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El paraguas":
                        if (numero != 5)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La sirena":
                        if (numero != 6)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La escalera":
                        if (numero != 7)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La botella":
                        if (numero != 8)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El barril":
                        if (numero != 9)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El arbol":
                        if (numero != 10)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El melon":
                        if (numero != 11)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El valiente":
                        if (numero != 12)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El gorrito":
                        if (numero != 13)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La muerte":
                        if (numero != 14)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La pera":
                        if (numero != 15)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La bandera":
                        if (numero != 16)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El bandolon":
                        if (numero != 17)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El violoncello":
                        if (numero != 18)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La garza":/**/
                        if (numero != 19)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El pajaro":
                        if (numero != 20)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La mano":
                        if (numero != 21)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La bota":
                        if (numero != 22)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La luna":
                        if (numero != 23)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El cotorro":
                        if (numero != 24)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El borracho":
                        if (numero != 25)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El negrito":
                        if (numero != 26)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El corazon":
                        if (numero != 27)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La sandia":
                        if (numero != 28)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El tambor":
                        if (numero != 29)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El camaron":
                        if (numero != 30)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "Las jaras":
                        if (numero != 31)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El musico":
                        if (numero != 32)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La araña":
                        if (numero != 33)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El soldado":
                        if (numero != 34)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La estrella":
                        if (numero != 35)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El venado":
                        if (numero != 36)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El mundo":
                        if (numero != 37)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El apache":
                        if (numero != 38)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El nopal":
                        if (numero != 39)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El alacran":
                        if (numero != 40)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La rosa":
                        if (numero != 41)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La calavera":
                        if (numero != 42)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La campana":
                        if (numero != 43)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El cantarito":
                        if (numero != 44)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El sol":
                        if (numero != 45)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El cazo":
                        if (numero != 46)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La corona":
                        if (numero != 47)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La chalupa":
                        if (numero != 48)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El pino":
                        if (numero != 49)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El pescado":
                        if (numero != 50)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La palma":
                        if (numero != 51)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La maceta":
                        if (numero != 52)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "El arpa":
                        if (numero != 53)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    case "La rana":
                        if (numero != 54)
                        {
                            {
                                yield return new ValidationResult("El numero y el nombre no coinciden",
                                new String[] { nameof(Nombre) });
                            }
                        }
                        break;
                    default:
                        yield return new ValidationResult("Extension Lada no valida",
                        new String[] { nameof(Nombre) });
                        break;
                }
            }
        }
    }
}
