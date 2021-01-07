using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Products.ViewModel
{


    public class Product : INotifyPropertyChanged
    {
        public int id { get; set; }
        private string groupName;
        private string productName;
        private string maker;
        private string productionDate;
        private int expiryTime;

        public Product(string groupName, string productName, string maker, string productionDate, int expiryTime)
        {
            this.groupName = groupName;
            this.productName = productName;
            this.maker = maker;

            //int[] dt = Converter(productionDate.Split(','));

            //this.productionDate = new DateTime(dt[1], dt[0], dt[2]);
            this.productionDate = productionDate;
            this.expiryTime = expiryTime;
        }

        public Product() { }


        private int[] Converter(string[] input)
        {
            int[] result = new int[input.Length];
            int j = 0;
            foreach(string i in input)
            {
                result[j] = Convert.ToInt32(i);
                j++;
            }
            return result;
        }

        public string GroupName
        {
            get { return groupName; }
            set
            {
                OnPropertyChanged("GroupName");
                groupName = value; 
            }
        }
        public string ProductName
        {
            get { return productName; }
            set 
            {
                OnPropertyChanged("ProductName");
                productName = value; 
            }
        }
        public string Maker
        {
            get { return maker; }
            set 
            {
                OnPropertyChanged("Maker");
                maker = value; 
            }
        }
        public string ProductionDate
        {
            get { return productionDate; }
            set 
            {
                OnPropertyChanged("ProductionDate");
                productionDate = value; 
            }
        }
        public int ExpiryTime
        {
            get { return expiryTime; }
            set 
            {
                OnPropertyChanged("ExpiryTime");
                expiryTime = value; 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
