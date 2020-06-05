using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Drawing;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace ImageSampler2
{
    public class ImageSampler2Component : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public ImageSampler2Component()
          : base("ImageSampler2", "IM2",
              "Description",
              "kazurati", "Utility")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("path", "path", "", GH_ParamAccess.item);
            pManager.AddVectorParameter("uv", "uv", "", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddColourParameter("RGB", "", "", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string path = "";
            List<Vector3d> uvPos = new List<Vector3d>();

            if (!DA.GetData(0, ref path)) return;
            if (!DA.GetDataList(1, uvPos)) return;

            var rgbList = new List<Color>();
            

            Bitmap bitmap = new Bitmap(path);
            int w = bitmap.Width -1;
            int h = bitmap.Height -1;

            for (int i = 0; i < uvPos.Count; i++)
            {
                int pixX = (int)Math.Floor(w * uvPos[i].X);
                int pixY = (int)Math.Floor(h * uvPos[i].Y);
                Color pixCol = bitmap.GetPixel(pixX, pixY);
                rgbList.Add(pixCol);
            }
            bitmap.Dispose();

            DA.SetDataList(0, rgbList);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("13cb63cf-2ff6-4643-9fda-006b16dc88b4"); }
        }
    }
}
