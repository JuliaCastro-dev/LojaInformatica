using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInfo.Models
{
    public class Funcionario
    {
        //cd_func int primary key auto_increment,
        //nm_func varchar(50) not null,
        //end_func varchar(150) not null,
        //cargo_func varchar(30),
        //tel_func varchar(11)


        [DisplayName("Código")]
        public string cd_func { get; set; }
        [Required(ErrorMessage = "O Nome é Obrigatório!!")]
        [DisplayName("Nome")]
        public string nm_func { get; set; }
        [Required(ErrorMessage = "O Endereço é Obrigatório!!")]
       
        [DisplayName("Endereço")]
        public string end_func { get; set; }
        [Required(ErrorMessage = "O Cargo é Obrigatório!!")]
     
        [DisplayName("Cargo")]
        public string cargo_func{ get; set; }
        [Required]
        [DisplayName("Telefone")]
        public string tel_func { get; set; }

        

    }
}