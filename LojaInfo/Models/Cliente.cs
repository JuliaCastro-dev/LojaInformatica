using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInfo.Models
{
    public class Cliente
    {
        [DisplayName("Código")]
        public string  cd_cliente { get; set; }


        [DisplayName("Nome")]
        [Required(ErrorMessage = "O Nome é Obrigatório!!")]
        public string  nm_cliente { get; set; }


        [DisplayName("Telefone")]
        [Required(ErrorMessage = "O Telefone é Obrigatório!!")]
        public string  tel_cliente { get; set; }


        [DisplayName("CPF")]
        [Required(ErrorMessage = "O CPF é Obrigatório!!")]
        public string  CPF_cliente { get; set; }


        [DisplayName("Endereço")]
        [Required(ErrorMessage = "O Endereço é Obrigatório!!")]
        public string end_cliente { get; set; }


       
        [DisplayName("Email")]
        [Required(ErrorMessage = "Informe o email")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Informe um email válido")]
        public string email_cliente { get; set; }
    }
}