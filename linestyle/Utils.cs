using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linestyle
{
    internal static class Utils
    {
        internal static List<string> GetAllLineStyles(Document doc)
        {
            //get all line styles
            Category c = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
            CategoryNameMap subCats = c.SubCategories;
            List<string> lineList = new List<string>();

            foreach (Category cat in subCats)
            {
                lineList.Add(cat.Name);
            }
            return lineList;
        }

        internal static LinePattern GetAllLinePatterns(Document doc)
        {
            FilteredElementCollector m_colLP = new FilteredElementCollector(doc);

            throw new NotImplementedException();
        }        

        //internal static GraphicsStyle GetLineStyleByName(Document doc, string lineStyle)
        //{
        //    // get all the linestyles
        //    List<string> listLS = GetAllLineStyles(doc);

        //    // loop through the linestyles & find "lineStyle"
        //    foreach(String curLS in listLS)
        //    {
        //        if (curLS == lineStyle)
        //            return  curLS
        //    }

        //    // return "lineStyle"
        //    throw new NotImplementedException();
        //}

        internal static LinePattern GetLinePatternByName(Document doc, string linePattern)
        {
            throw new NotImplementedException();
        }

        public static List<string> getAllLinePatterns(Document curDoc)
        {
            //get list of line patterns
            FilteredElementCollector lpCol = new FilteredElementCollector(curDoc);
            lpCol.OfClass(typeof(LinePatternElement));

            List<string> lpList = new List<string>();

            foreach (LinePatternElement l in lpCol.ToElements())
            {
                lpList.Add(l.Name);
            }
            return lpList;
        }

        public static LinePatternElement getLinePatternByName(Document curDoc, string typeName)
        {
            if (typeName != null)
                return LinePatternElement.GetLinePatternElementByName(curDoc, typeName);
            else
                return null;
        }

        public static GraphicsStyle getLinestyleByName(Document curDoc, string styleName)
        {
            GraphicsStyle retlinestyle = null;

            FilteredElementCollector gstylescollector = new FilteredElementCollector(curDoc);
            gstylescollector.OfClass(typeof(GraphicsStyle));

            foreach (Element element in gstylescollector)
            {
                GraphicsStyle curLS = element as GraphicsStyle;

                if (curLS.Name == styleName)
                    retlinestyle = curLS;
            }


            return retlinestyle;
        }
    }
}
