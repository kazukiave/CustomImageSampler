using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Linq;

namespace ImageSampler2
{
    public class ToUV : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ToUV class.
        /// </summary>
        public ToUV()
          : base("ToUV", "Nickname",
              "Description",
              "Category", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddVectorParameter("pos", "", "", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddVectorParameter("uv", "", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var positions = new List<Vector3d>();
            
            if (!DA.GetDataList(0, positions));
            var uv = new List<Vector3d>(); 

            var xVals = new List<double>();
            var yVals = new List<double>();


            foreach (var pos in positions)
            {
                xVals.Add(pos.X);
                yVals.Add(pos.Y);
            }
            double maxX = xVals.Max();
            double minX = xVals.Min();
            double maxY = yVals.Max();
            double minY = yVals.Min();

            foreach(var pos in positions)
            {
                double x = pos.X.RemapNumber(minX, maxX, 0, 1);
                double y = pos.Y.RemapNumber(minY, maxY, 0, 1);

                Vector3d uvPos = new Vector3d(x, y, 0);
                uv.Add(uvPos);
            }

            DA.SetDataList(0, uv);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("050fb6a8-8f2d-42e0-80f7-00bb49aafa94"); }
        }
    }
}