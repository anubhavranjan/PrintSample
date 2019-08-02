using System;
using System.Collections.Generic;
using System.Text;

namespace PrintSample
{
    public class DocumentHelper
    {
        public string Content { get; set; }

        public DocumentHelper()
        {
            this.Content = @"<!DOCTYPE html>
<html>
  <head>
    <style>
    body {
        width: 100%;
        margin-left: auto;
        margin-right: auto;
    }
    </style>
  </head>
  <body>
           RESTAURENT       
              ABC              
        INVOICE RECIEPT        
================================
Bill No: bnoid     Pos No: 9
Cashier:                 
================================
bodycontent
================================
Items/Qty:               1/1
================================
Paid By:                    
Cash :                   RS 70.00
================================
GST:                       
GST18%                      10.68
scheme :1
================================
            Message            
================================
  </body>
</html>";
        }
    }
}
