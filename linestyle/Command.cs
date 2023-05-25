#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace linestyle
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // get the line style called <Centerline>
            GraphicsStyle curCenterline = Utils.getLinestyleByName(doc, "<Centerline>");

            // get the line pattern called: Center 1/8"
            LinePatternElement newCenterLP = Utils.getLinePatternByName(doc, "Center 1/8\"");

            using (Transaction t = new Transaction(doc))
            {
                t.Start("Update Centerline");

                    curCenterline.GraphicsStyleCategory.SetLinePatternId(newCenterLP.Id, GraphicsStyleType.Projection);

                t.Commit();
            }
            
            return Result.Succeeded;
        }
    }
}
