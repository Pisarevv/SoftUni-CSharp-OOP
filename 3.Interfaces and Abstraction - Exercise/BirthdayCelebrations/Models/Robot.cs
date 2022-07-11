using BirthdatCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdatCelebrations.Models
{
    public class Robot : IIdentifiable
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                model = value;
            }
        }
        public string Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }
    }
}