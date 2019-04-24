using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RideServiceGroup1.Entities;

namespace RideServiceGroup1.DAL
{
    public interface IRepository
    {
        List<DataTable> HandleData();
        List<IEntity> GetAll();
        IEntity GetById();
    }
}
