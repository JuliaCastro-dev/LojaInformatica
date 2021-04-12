using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LojaInfo.Models
{
    public class Vendas { 
        public string qtVendas { get; set; }

        //vend.cd_venda,
        //vend.cd_cliente,
        //vend.dt_venda,
        //vend.tp_pagamento,
        //cli.end_cliente, 
        //vend.vl_total,
        //cli.nm_cliente
        [DisplayName("Código Da venda ")]
        public string cd_venda{ get; set; }
        [DisplayName("Código Do Cliente ")]
        public string cd_cliente { get; set; }
        [DisplayName("Data Da venda ")]
        public string dt_venda { get; set; }
        [DisplayName("Tipo de Pagamento ")]
        public string tp_pagamento{ get; set; }
        [DisplayName("Endereço")]

        public string end_cliente { get; set; }
        [DisplayName("Valor Total")]

        public string vl_total { get; set; }
        

    }
}