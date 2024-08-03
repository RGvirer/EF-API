﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;

namespace BL
{
    public class PatientsServices : IBL.IObjectBL
    {
        private readonly IObjectDAL patientDal;

        public PatientsServices(IObjectDAL patientDal)
        {
            this.patientDal = patientDal;
        }

        public bool AddNew(object item)
        {
            try
            {
                return patientDal.AddNew(item);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(object item)
        {
            try
            {
                return patientDal.Delete(item);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Get(object item)
        {
            throw new NotImplementedException();
        }

        public List<object> GetAll()
        {
            try
            {
                return patientDal.GetAll();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(object item)
        {
            try
            {
                return patientDal.Update(item);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
