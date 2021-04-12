using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInfo.Models
{
    public class Venda
    {
        //cd_venda int primary key auto_increment,
        //cd_cliente int not null,
        //dt_venda datetime,
        //tp_pagamento varchar(60),
        //end_cliente varchar(150) not null references tbl_cliente(end_cliente),
        //vl_total int not null,
        //qt_produto int,
        //nm_produto varchar(25),

        [DisplayName("Código Da venda ")]
        public string cd_venda { get; set; }
        [DisplayName( "Código do cliente ")]
        public string cd_cliente { get; set; }
        [DisplayName ("Data da venda")]
        public string dt_venda { get; set; }
        [DisplayName ( "Tipo de pagamento")]
        public string  tp_pagamento { get; set; }
        [DisplayName ("Endereço do cliente ")]
        public string end_cliente { get; set; }

        [DisplayName("Valor Total")]
        public Decimal vl_total{ get; set; }
        [DisplayName("Produto")]
        public string nm_produto { get; set; }

        [DisplayName("Quantidade")]
        public int qt_produto { get; set; }


    }
}