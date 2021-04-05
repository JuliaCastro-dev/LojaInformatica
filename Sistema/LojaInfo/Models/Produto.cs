using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInfo.Models
{
    public class Produto
    {
        //nm_produto varchar(25) primary key,
        //qt_estoque int not null,
        //vl_produto decimal (10,2) not null,
        //desc_produto varchar(15) not null,
        //setor_produto varchar(15) not null,
        //marca_produto varchar(50) not null
        //img_small blob,
        //img_medium mediumblob
        [DisplayName("Produto")]
        [Required(ErrorMessage = "O Campo é Obrigatório!!")]
        public string produto { get; set; }

        [DisplayName("Estoque")]
        [Required(ErrorMessage = "O Campo é Obrigatório!!")]
        public string qt_estoque { get; set; }

        [DisplayName("Valor")]
        [Required(ErrorMessage = "O Campo é Obrigatório!!")]
        public Decimal valor_prod { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O Campo é Obrigatório!!")]
        public string  desc_produto{ get; set; }

        [DisplayName("Setor")]
        [Required(ErrorMessage = "O Campo é Obrigatório!!")]
        public string setor_produto { get; set; }

        [DisplayName("Marca")]
        [Required(ErrorMessage = "O Campo é Obrigatório!!")]
        public string marca_produto { get; set; }

        [DisplayName("Imagem")]
        [Required(ErrorMessage = "O Campo é Obrigatório!!")]
        public string img { get; set; }
    }
}