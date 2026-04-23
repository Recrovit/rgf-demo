using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Data;
using Recrovit.RecroGridFramework.Security;
using System;
using System.Linq;
using System.Text;

namespace RGF.Demo.Northwind.Models;

public partial class Products : IRecroGridUpdate
{
    public bool RecroGridUpdate(IRGDataContext context, RGClientParam param, RGUIMessages messages)
    {
        return true;
    }

    public static int Preprocessing(RecroSecProcessingParam param)
    {
        object dataRec = param.Target;
        if (param.ObjectName.IndexOf("/") == -1)
        {
            if (dataRec is Products && ((Products)dataRec).Discontinued)
            {
                return 2;
            }
            if (dataRec is RecroGrid.RGClientColumn[])
            {
                var clientRec = (RecroGrid.RGClientColumn[])dataRec;
                var discontinued = clientRec.SingleOrDefault(r => r.Property.Alias.Equals("discontinued", StringComparison.InvariantCultureIgnoreCase));
                if (discontinued != null && ((bool)discontinued.DbValue)/*&& param.UserId == ...*/)
                {
                    return 2;
                }
            }
        }
        return param.ObjectPermissionId;
    }

    public static void Postprocessing(RecroSecProcessingParam param, UserPermissions permissions)
    {
        object dataRec = param.Target;
        if (param.ObjectName.IndexOf("/") == -1)
        {
            if (dataRec is Products && ((Products)dataRec).Discontinued/*&& param.UserId == ...*/)
            {
                //permissions.CRUD = "R";
            }
            if (dataRec is RecroGrid.RGClientColumn[])
            {
                var clientRec = (RecroGrid.RGClientColumn[])dataRec;
                var discontinued = clientRec.SingleOrDefault(r => r.Property.Alias.Equals("discontinued", StringComparison.InvariantCultureIgnoreCase));
                if (discontinued != null && ((bool)discontinued.DbValue)/*&& param.UserId == ...*/)
                {
                    permissions.CRUD = "";
                }
            }
        }
    }
}
