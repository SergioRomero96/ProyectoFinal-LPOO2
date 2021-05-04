using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace ClasesBases.Services.Extension
{
    public class TerminalMapper
    {
        public static Terminal ToTerminal(DataTable dtTerminal)
        {
            Terminal terminal = new Terminal();
            terminal.Ter_Id = Convert.ToInt32(dtTerminal.Rows[0][0]);
            terminal.Ter_Codigo = Convert.ToInt32(dtTerminal.Rows[0][1]);
            terminal.Ter_Nombre = dtTerminal.Rows[0][3].ToString();
            return terminal;
        }
    }
}
