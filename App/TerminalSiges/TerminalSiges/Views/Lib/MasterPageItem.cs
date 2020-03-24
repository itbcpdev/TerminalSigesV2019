using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalSIGES.Views.Lib {
  public class MasterPageItem {
    public string Titulo { get; set; }
    public string Icono { get; set; }
    public string FontFamily { get; set; }
    public System.Type PaginaACargar { get; set; }
    public bool EsInicio { get; set; } 
  }
}
