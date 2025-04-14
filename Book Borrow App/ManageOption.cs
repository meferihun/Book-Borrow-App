using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Borrow_App
{
    internal class ManageOption
    {
        private string _selectedOption;
        private List<string> _selectedOptionList;

        public ManageOption(List<string> options, string selectedOption) 
        { 
            _selectedOption = selectedOption;
        }


    }
}
