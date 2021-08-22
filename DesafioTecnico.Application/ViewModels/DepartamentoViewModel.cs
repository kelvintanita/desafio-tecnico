using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecnico.Application.ViewModels
{
    public class DepartamentoViewModel : DepartamentoCreateEditViewModel
    {
        public int Id { get; set; }
    }

    public class DepartamentoCreateEditViewModel
    {
        public string Nome { get; set; }
    }
}
