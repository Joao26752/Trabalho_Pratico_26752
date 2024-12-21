using Trabalho_Pratico_26752.Classes;
using Trabalho_Pratico_26752;
using System;

namespace Trabalho_Pratico_26752.Classes
{
    public class Product
    {
        #region Fields
        private int _id;
        private string _name;
        private string _description;
        #endregion

        #region Properties
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }
        #endregion
    }
}
