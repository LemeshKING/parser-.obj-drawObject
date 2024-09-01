﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using System.Globalization;
using System.IO;
using System.Drawing.Imaging;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Primitives;
using Index = SharpGL.SceneGraph.Index;

namespace WindowsFormsApp7
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {

      }

      private void trackBar2_Scroll(object sender, EventArgs e)
      {
         label5.Text = "Текущие значение: " + trackBar2.Value.ToString();
      }

      private void textBox1_TextChanged(object sender, EventArgs e)
      {

      }

      private void textBox2_TextChanged(object sender, EventArgs e)
      {

      }

      private void label3_Click(object sender, EventArgs e)
      {

      }

      private void label5_Click(object sender, EventArgs e)
      {

      }



      private void TranslationOfCoordinates()
      {
         const double eqRadius = 6378245;
         const double poRadius = 6356777;
         double x, y, z;
         double eccentricity, curvatureOfRadius;
         eccentricity = Math.Sqrt((Math.Pow(eqRadius, 2) - Math.Pow(poRadius, 2)) / Math.Pow(eqRadius, 2));
         curvatureOfRadius = eqRadius / Math.Sqrt(1 - Math.Pow(eccentricity, 2) * Math.Pow(Math.Sin(double.Parse(textBox1.Text)), 2));
         x = curvatureOfRadius * Math.Cos(double.Parse(textBox1.Text) * Math.PI / 180) * Math.Cos(double.Parse(textBox2.Text) * Math.PI / 180);
         y = curvatureOfRadius * Math.Cos(double.Parse(textBox1.Text) * Math.PI / 180) * Math.Sin(double.Parse(textBox2.Text) * Math.PI / 180);
         z = Math.Pow(poRadius, 2) / Math.Pow(eqRadius, 2) * curvatureOfRadius * Math.Sin(double.Parse(textBox1.Text) * Math.PI / 180);
         Calculeted(x, y, z);
      }

      private void button1_Click(object sender, EventArgs e)
      {
         try
         {
            if (int.Parse(textBox1.Text) > 90 | int.Parse(textBox1.Text) < -90)
               MessageBox.Show("Широта меняется от -90 до 90");
            else if (int.Parse(textBox2.Text) > 180 | int.Parse(textBox2.Text) < -180)
               MessageBox.Show("Долгота меняется от -180 до 180");
            else
               TranslationOfCoordinates();
         }
         catch(Exception ex)
         {
            MessageBox.Show(ex.Message + " Введите координаты!");
         }
      }
      Polygon polygon;
      private void openGLControl1_Load(object sender, EventArgs e)
      {
         polygon = LoadData("KolcaGelmgolca_tn111.obj");
      }
      double rotationX = 0d;

      bool flag = false;
      private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
      {
         OpenGL gl = openGLControl1.OpenGL;
         gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
         Texture texture = new Texture();
         Bitmap Image = new Bitmap("2.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         if (flag)
         for (int i = 0; i < 24; i++)
            for (int j = 0; j < 3; j++)
            {
               double x = polygon.Vertices[polygon.Faces[i].Indices[j].Vertex].Z * Math.Cos(-anglePosition * Math.PI / 180 + 5 * Math.PI / 4) - polygon.Vertices[polygon.Faces[i].Indices[j].Vertex].X * Math.Sin(-anglePosition * Math.PI / 180 + 5 * Math.PI / 4);
               double y = polygon.Vertices[polygon.Faces[i].Indices[j].Vertex].Y;
               double z = polygon.Vertices[polygon.Faces[i].Indices[j].Vertex].Z * Math.Sin(-anglePosition * Math.PI / 180 + 5 * Math.PI / 4) + polygon.Vertices[polygon.Faces[i].Indices[j].Vertex].X * Math.Cos(-anglePosition * Math.PI / 180 + 5 * Math.PI / 4);
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(x,y,z);
            }
         else
            for (int i = 0; i < 24; i++)
               for (int j = 0; j < 3; j++)
               {
                  double x = polygon.Vertices[polygon.Faces[i].Indices[j].Vertex].Z * Math.Cos(5*Math.PI / 4) - polygon.Vertices[polygon.Faces[i].Indices[j].Vertex].X * Math.Sin(5*Math.PI / 4);
                  double y = polygon.Vertices[polygon.Faces[i].Indices[j].Vertex].Y;
                  double z = polygon.Vertices[polygon.Faces[i].Indices[j].Vertex].Z * Math.Sin(5*Math.PI / 4) + polygon.Vertices[polygon.Faces[i].Indices[j].Vertex].X * Math.Cos(5*Math.PI / 4);
                  gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
                  gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
                  gl.Vertex(x,y,z);
               }
         gl.End();
         Image = new Bitmap("3.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 24; i < 60; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();
         Image = new Bitmap("5.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 60; i < 204; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();
         Image = new Bitmap("4.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 204; i < 254; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();
         Image = new Bitmap("3.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 254; i < 266; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();
         Image = new Bitmap("6.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 266; i < 278; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();
         Image = new Bitmap("7.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 278; i < 1318; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();
         Image = new Bitmap("3.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 1318; i < 1350; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();
         Image = new Bitmap("5.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 1350; i < 2024; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();
         Image = new Bitmap("3.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 2024; i < 2290; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();
         Image = new Bitmap("10.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 2290; i < 3250; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();
         Image = new Bitmap("9.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 3250; i < 5622; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();
         Image = new Bitmap("11.jpg");
         texture.Create(gl, Image);
         gl.Enable(OpenGL.GL_TEXTURE_2D);
         texture.Bind(gl);
         gl.Begin(OpenGL.GL_TRIANGLES);
         for (int i = 5622; i < 6202; i++)
            for (int j = 0; j < 3; j++)
            {
               gl.TexCoord(polygon.UVs[polygon.Faces[i].Indices[j].UV]);
               gl.Normal(polygon.Normals[polygon.Faces[i].Indices[j].Normal]);
               gl.Vertex(polygon.Vertices[polygon.Faces[i].Indices[j].Vertex]);
            }
         gl.End();

         gl.LoadIdentity();
         gl.Rotate(rotationX, 0d, 1d, 0d);


      }

      private void openGLControl1_Resized(object sender, EventArgs e)
      {
         OpenGL gl = openGLControl1.OpenGL;

         gl.MatrixMode(OpenGL.GL_PROJECTION);


         gl.LoadIdentity();


         gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);


         gl.LookAt(2, 5, -7,    
                     0, 2, 0,     
                     0, 1, 0);    

        
         gl.MatrixMode(OpenGL.GL_MODELVIEW);
      }
      private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
      {

      }
      Polygon LoadData(string name)
      {
         string line;
         Polygon polygon = new Polygon();
         using (StreamReader reader = new StreamReader(name))
         {
            while ((line = reader.ReadLine()) != null)
            {

               if (line.StartsWith("vt"))
               {

                  string[] values = line.Split(' ');
                  float x = float.Parse(values[1], CultureInfo.InvariantCulture);
                  float y = float.Parse(values[2], CultureInfo.InvariantCulture);


                  float u = x;
                  float v = 1.0f - y;


                  polygon.UVs.Add(new UV(u, v));
                  continue;
               }


               if (line.StartsWith("v "))
               {

                  string[] values = line.Split(' ');


                  float x = float.Parse(values[1], CultureInfo.InvariantCulture);
                  float y = float.Parse(values[2], CultureInfo.InvariantCulture);
                  float z = float.Parse(values[3], CultureInfo.InvariantCulture);


                  polygon.Vertices.Add(new Vertex(x, y, z));
                  continue;
               }
               if (line.StartsWith("vn "))
               {

                  string[] values = line.Split(' ');


                  float x = float.Parse(values[1], CultureInfo.InvariantCulture);
                  float y = float.Parse(values[2], CultureInfo.InvariantCulture);
                  float z = float.Parse(values[3], CultureInfo.InvariantCulture);

                  polygon.Normals.Add(new Vertex(x, y, z));
                  continue;
               }
               if (line.StartsWith("f"))
               {
                  Face face = new Face();                 
                  string[] indices = line.Substring(2).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                  foreach (var index in indices)
                  {

                     string[] parts = index.Split(new char[] { '/' }, StringSplitOptions.None);

                     face.Indices.Add(new Index(
                         (parts.Length > 0 && parts[0].Length > 0) ? int.Parse(parts[0], CultureInfo.InvariantCulture) - 1 : -1,
                         (parts.Length > 1 && parts[1].Length > 0) ? int.Parse(parts[1], CultureInfo.InvariantCulture) - 1 : -1,
                         (parts.Length > 2 && parts[2].Length > 0) ? int.Parse(parts[2], CultureInfo.InvariantCulture) - 1 : -1));
                  }

 
                  polygon.Faces.Add(face);
                  continue;
               }
            }

         }
         return polygon;
      }
     
      private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
            rotationX = e.X;
        
      }

      private void openGLControl1_MouseClick(object sender, MouseEventArgs e)
      {
        
      }
      double ScalarMultiplication(radiusVector X, radiusVector Y)
      {
         double result = (X.x * Y.x) + (X.y * Y.y) + (X.z * Y.z);
         return result;
      }
      double CalcVectorLength(radiusVector X)
      {
         double result = Math.Sqrt(ScalarMultiplication(X, X));
         return result;
      }
      double anglePosition = 0, inclination = 0;
      

      void Calculeted(double x, double y, double z)
      {
         radiusVector nGeomagnPole = new radiusVector();
         radiusVector pointOnEarth = new radiusVector();
         radiusVector dipol = new radiusVector();
         const double magneticConstant = 4 * Math.PI * 0.0000001;
         double magneticMoment = 7.72 * Math.Pow(10, 25);
         double Bh, Bv;
         double K = 722; 
         double I = (double)trackBar2.Value / 100 ; 
         nGeomagnPole.x = 319763;
         nGeomagnPole.y = -1021613;
         nGeomagnPole.z = 6266608;
         pointOnEarth.x = x; 
         pointOnEarth.y = y;
         pointOnEarth.z = z;
         dipol.x = -1201640;
         dipol.y = 882214;
         dipol.z = 309566;
         double angle;
         double R;
         double geomagneticLatitude;
         angle = Math.Acos(ScalarMultiplication(nGeomagnPole, pointOnEarth) / (CalcVectorLength(nGeomagnPole) * CalcVectorLength(pointOnEarth)));
         geomagneticLatitude = (Math.PI / 2) - angle;
         R = CalcVectorLength(pointOnEarth);
         Bh = magneticConstant * magneticMoment * Math.Cos(geomagneticLatitude) / (4 * Math.PI * R * R * R);
         double BH = I * K ;
         anglePosition = Math.Atan(BH / (Bh * 1000)) * 180 / Math.PI;
         label6.Text = "Угол поворота магнитнитной стрелки: " + Math.Round(anglePosition, 2).ToString();
         Bv = magneticConstant * magneticMoment * Math.Sin(geomagneticLatitude) / (2 * Math.PI * R * R * R);
         inclination = Math.Atan(Bv / Bh) * 180 / Math.PI;
         label7.Text = "Наклонение: " + Math.Round(inclination, 2).ToString();
         flag = true;

      }

      private void label8_Click(object sender, EventArgs e)
      {

      }

      private void label6_Click(object sender, EventArgs e)
      {

      }
   }
   class radiusVector
   {
      public double x = 0;
      public double y = 0;
      public double z = 0;
   }
}

