﻿using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Drawing;

namespace IntraLattice
{
    public class InputTools
    {
        public static int ExecutionNum { get; set; }

        //Static constructor that is supposed to execute only once
        static InputTools()
        {
            ExecutionNum = 0;
        }

        // index represents the input position (first input is index == 0)
        public static void TopoSelect(ref IGH_Component Component, ref GH_Document GrasshopperDocument, int index, float offset)
        {
            //instantiate  new value list
            var vallist = new Grasshopper.Kernel.Special.GH_ValueList();
            vallist.ListMode = Grasshopper.Kernel.Special.GH_ValueListMode.Cycle;
            vallist.CreateAttributes();

            //customise value list position
            float xCoord = (float)Component.Attributes.Pivot.X - 200;
            float yCoord = (float)Component.Attributes.Pivot.Y + index * 40 - offset;
            PointF cornerPt = new PointF(xCoord, yCoord);
            vallist.Attributes.Pivot = cornerPt;

            //populate value list with our own data
            vallist.ListItems.Clear();
            var item1 = new Grasshopper.Kernel.Special.GH_ValueListItem("Grid", "0");
            var item2 = new Grasshopper.Kernel.Special.GH_ValueListItem("X", "1");
            var item3 = new Grasshopper.Kernel.Special.GH_ValueListItem("Star", "2");
            var item4 = new Grasshopper.Kernel.Special.GH_ValueListItem("Cross", "3");
            var item5 = new Grasshopper.Kernel.Special.GH_ValueListItem("Cross2", "4");
            vallist.ListItems.Add(item1);
            vallist.ListItems.Add(item2);
            vallist.ListItems.Add(item3);
            vallist.ListItems.Add(item4);
            vallist.ListItems.Add(item5);

            // Until now, the slider is a hypothetical object.
            // This command makes it 'real' and adds it to the canvas.
            GrasshopperDocument.AddObject(vallist, false);

            //Connect the new slider to this component
            Component.Params.Input[index].AddSource(vallist);
            Component.Params.Input[index].CollectData();
        }

        public static void BooleanSelect(ref IGH_Component Component, ref GH_Document GrasshopperDocument, int index, float offset)
        {
            //instantiate  new value list
            var boollist = new Grasshopper.Kernel.Special.GH_BooleanToggle();
            boollist.CreateAttributes();

            //customise value list position
            float xCoord = (float)Component.Attributes.Pivot.X - 200;
            float yCoord = (float)Component.Attributes.Pivot.Y + index*40 - offset;
            PointF cornerPt = new PointF(xCoord, yCoord);
            boollist.Attributes.Pivot = cornerPt;
            
            // Until now, the slider is a hypothetical object.
            // This command makes it 'real' and adds it to the canvas.
            GrasshopperDocument.AddObject(boollist, false);
            //Connect the new slider to this component
            Component.Params.Input[index].AddSource(boollist);
            Component.Params.Input[index].CollectData();
            // Little hack, required because of how booleantoggle is rendered
            boollist.ExpireSolution(true);
        }

        public static void IntegerSelect(ref IGH_Component Component, ref GH_Document GrasshopperDocument, int index, float offset, int min, int max)
        {
            //instantiate  new value list
            var intslider = new Grasshopper.Kernel.Special.GH_NumberSlider();
            intslider.Slider.Minimum = min;
            intslider.Slider.Maximum = max;
            intslider.Slider.Type = Grasshopper.GUI.Base.GH_SliderAccuracy.Integer;
            intslider.CreateAttributes();

            //customise value list position
            float xCoord = (float)Component.Attributes.Pivot.X - 200;
            float yCoord = (float)Component.Attributes.Pivot.Y + index * 40;
            PointF cornerPt = new PointF(xCoord, yCoord);
            intslider.Attributes.Pivot = cornerPt;

            // Until now, the slider is a hypothetical object.
            // This command makes it 'real' and adds it to the canvas.
            GrasshopperDocument.AddObject(intslider, false);

            //Connect the new slider to this component
            Component.Params.Input[index].AddSource(intslider);
        }

        public static void FloatSelect(ref IGH_Component Component, ref GH_Document GrasshopperDocument, int index, float offset, int min, int max)
        {
            //instantiate  new value list
            var floatslider = new Grasshopper.Kernel.Special.GH_NumberSlider();
            floatslider.Slider.Minimum = min;
            floatslider.Slider.Maximum = max;
            floatslider.Slider.Type = Grasshopper.GUI.Base.GH_SliderAccuracy.Float;

            floatslider.CreateAttributes();

            //customise value list position
            float xCoord = (float)Component.Attributes.Pivot.X - 200;
            float yCoord = (float)Component.Attributes.Pivot.Y + index * 40;
            PointF cornerPt = new PointF(xCoord, yCoord);
            floatslider.Attributes.Pivot = cornerPt;

            // Until now, the slider is a hypothetical object.
            // This command makes it 'real' and adds it to the canvas.
            GrasshopperDocument.AddObject(floatslider, false);

            //Connect the new slider to this component
            Component.Params.Input[index].AddSource(floatslider);
        }



    }
}