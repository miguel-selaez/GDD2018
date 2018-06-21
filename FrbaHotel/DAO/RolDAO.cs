﻿using FrbaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.DAO
{
    public class RolDAO : BaseDAO<Rol>
    {

        public List<Rol> GetRolesByUserId(int userId)
        {
            var list = new List<Rol>();

            var query = ArmarSentenciaSP("P_Obtener_Roles_x_Usuario", new[] { GetParam(userId) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0) {
                foreach (DataRow row in result.Rows) {
                    list.Add(new Rol(row));
                }
            }
            return list;
        }
    }
}
