﻿using System.ComponentModel.DataAnnotations;

namespace Pokedex.API.Models
{
    public class LoginUserModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato inválido do campo {0}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "Tamanho máximo do campo {0} é 100")]
        public string Password { get; set; }
    }
}
