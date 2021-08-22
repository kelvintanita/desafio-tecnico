using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecnico.Application.ViewModels
{
    public class CategoriaViewModel : CategoriaCreateEditViewModel
    {
        public int Id { get; set; }
    }

    public class CategoriaCreateEditViewModel
    {
        public string Nome { get; set; }
    }
}
