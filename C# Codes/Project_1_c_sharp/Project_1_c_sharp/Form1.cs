using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1_c_sharp
{
    public partial class Form1 : Form
    {

        DataTable edges_table = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            edges_table.Columns.Add("Edge_a", typeof(int));
            edges_table.Columns.Add("Edge_b", typeof(int));
            edges_table.Columns.Add("Weight", typeof(int));
            dataGridView1.DataSource = edges_table;
        }

        
        /*--------------------------------------Degree centrality----------------------------------------------------*/
        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text); // nodes
            int m = int.Parse(textBox2.Text); // edges

            int[] adj_a = new int[100];
            int[] adj_b = new int[100];
            int[] weight_array = new int[100];
            int[] count = new int[100];

            //Datagrid values (edges)
            for (int i = 0; i < m; i++)
            {
                //edge a
                var e_a = dataGridView1.Rows[i].Cells[0].Value; // take value of cell
                string ed_a;
                ed_a = e_a.ToString(); // change it to string
                int edge_a = int.Parse(ed_a);
                //edge b
                var e_b = dataGridView1.Rows[i].Cells[1].Value; // take value of cell
                string ed_b;
                ed_b = e_b.ToString();// change it to string
                int edge_b = int.Parse(ed_b);
                //weight
                var w = dataGridView1.Rows[i].Cells[2].Value; // take value of cell
                string wa;
                wa = w.ToString(); // change it to string
                int weight = int.Parse(wa);

                adj_a[i] = edge_a;
                adj_b[i] = edge_b;
                weight_array[i] = weight;

            }
            //find degree of each node
            for (int i = 0; i < m; i++)
            {
                count[adj_a[i]]++;
                count[adj_b[i]]++;
            }


            int[,] location = new int[100, 2] { { 500, 100 }, { 500, 200 }, { 950, 100 }, { 950, 200 }, { 700, 550 }, { 900, 500 }, { 550, 250 }, {550, 500}, {550, 430}, {910, 420},
                                               {730, 300}, {740, 400}, { 630, 100 }, { 690, 200 }, { 640, 400 }, { 800, 200 }, { 840, 550 }, { 800, 450 }, { 800, 250 }, {860, 50},
                                               {600, 50}, {600, 300}, {500, 300 }, { 700, 50}, {900, 100}, {740, 200}, {860, 100}, {910, 150}, {550, 690}, {600, 690},
                                                {900, 600 }, {730, 700}, {630, 400}, {840, 100}, { 840, 690}, { 950, 500}, {950, 600}, {800, 700}, {860, 500}, {900, 700},
                                                {1100, 600 }, {1200, 700}, {1130, 400}, {840, 100}, { 840, 450}, { 1150, 500}, {950, 50}, {800, 460}, {860, 50}, {900, 70},
                                                {1200, 600 }, {1100, 700}, {1460, 400}, {1300, 100}, { 1400, 400}, { 1250, 500}, {950, 600}, {600, 600}, {705, 500}, {910, 650},
                                                {1300, 600 }, {1200, 700}, {1340, 400}, {1200, 100}, { 1300, 700}, { 1400, 500}, {950, 600}, {700, 700}, {1100, 500}, {1000, 700},
                                                {1400, 600 }, {1330, 700}, {1240, 400}, {1150, 100}, { 1200, 700}, { 1300, 500}, {1400, 600}, {800, 690}, {760, 500}, {1000, 460},
                                                {1250, 530 }, {1420, 700}, {1370, 400}, {510, 100}, { 1150, 640}, { 1200, 500}, {1300, 600}, {1400, 700}, {560, 500}, {1230, 605},
                                                {1350, 600 }, {1240, 700}, {1147, 400}, {640, 100}, { 840, 670}, { 1150, 500}, {1250, 600}, {1300, 700}, {1290, 500}, {1350, 700}};

            for (int i = 0; i < m; i++)
            {
                draw_2_nodes_and_line(location[adj_a[i], 0], location[adj_a[i], 1], location[adj_b[i], 0], location[adj_b[i], 1], count[adj_a[i]] * 10, count[adj_b[i]] * 10, adj_a[i], adj_b[i], weight_array[i]);
            }
            
            //display centrality in a text box
            string str = "";
            for(int o = 0; o < n; o++)
            {
                str += "Node" + " " + o.ToString() + " --->" + count[o] + " | ";
            }
            textBox3.Text = str;
        }
        /*--------------------------------------Closeness centrality----------------------------------------------------*/
        private void button2_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text); // nodes
            int m = int.Parse(textBox2.Text); // edges

            int[] adj_a = new int[100];
            int[] adj_b = new int[100];
            int[] weight_array = new int[100];
            float[] count = new float[100];
            int[,] adj_matrix = new int[100, 100];


            //Datagrid values (edges)
            for (int i = 0; i < m; i++)
            {
                //edge a
                var e_a = dataGridView1.Rows[i].Cells[0].Value; // take value of cell
                string ed_a;
                ed_a = e_a.ToString(); // change it to string
                int edge_a = int.Parse(ed_a);
                //edge b
                var e_b = dataGridView1.Rows[i].Cells[1].Value; // take value of cell
                string ed_b;
                ed_b = e_b.ToString();// change it to string
                int edge_b = int.Parse(ed_b);
                //weight
                var w = dataGridView1.Rows[i].Cells[2].Value; // take value of cell
                string wa;
                wa = w.ToString(); // change it to string
                int weight = int.Parse(wa);

                adj_a[i] = edge_a;
                adj_b[i] = edge_b;
                weight_array[i] = weight;

                
            }

            for (int j = 0; j < m; j++)
            {
                adj_matrix[adj_a[j], adj_b[j]] = weight_array[j];
                adj_matrix[adj_b[j], adj_a[j]] = weight_array[j];
            }

            for (int i = 0; i < n; i++)
            {
                float opop = dijkstra(adj_matrix, i, n);
                count[i] = (n - 1) / (dijkstra(adj_matrix, i, n)); // this is the radius
            }


            int[,] location = new int[100, 2] { { 500, 100 }, { 500, 200 }, { 950, 100 }, { 950, 200 }, { 700, 550 }, { 900, 500 }, { 550, 250 }, {550, 500}, {550, 430}, {910, 420},
                                               {730, 300}, {740, 400}, { 630, 100 }, { 690, 200 }, { 640, 400 }, { 800, 200 }, { 840, 550 }, { 800, 450 }, { 800, 250 }, {860, 50},
                                               {600, 50}, {600, 300}, {500, 300 }, { 700, 50}, {900, 100}, {740, 200}, {860, 100}, {910, 150}, {550, 690}, {600, 690},
                                                {900, 600 }, {730, 700}, {630, 400}, {840, 100}, { 840, 690}, { 950, 500}, {950, 600}, {800, 700}, {860, 500}, {900, 700},
                                                {1100, 600 }, {1200, 700}, {1130, 400}, {840, 100}, { 840, 450}, { 1150, 500}, {950, 50}, {800, 460}, {860, 50}, {900, 70},
                                                {1200, 600 }, {1100, 700}, {1460, 400}, {1300, 100}, { 1400, 400}, { 1250, 500}, {950, 600}, {600, 600}, {705, 500}, {910, 650},
                                                {1300, 600 }, {1200, 700}, {1340, 400}, {1200, 100}, { 1300, 700}, { 1400, 500}, {950, 600}, {700, 700}, {1100, 500}, {1000, 700},
                                                {1400, 600 }, {1330, 700}, {1240, 400}, {1150, 100}, { 1200, 700}, { 1300, 500}, {1400, 600}, {800, 690}, {760, 500}, {1000, 460},
                                                {1250, 530 }, {1420, 700}, {1370, 400}, {510, 100}, { 1150, 640}, { 1200, 500}, {1300, 600}, {1400, 700}, {560, 500}, {1230, 605},
                                                {1350, 600 }, {1240, 700}, {1147, 400}, {640, 100}, { 840, 670}, { 1150, 500}, {1250, 600}, {1300, 700}, {1290, 500}, {1350, 700}};

            for (int i = 0; i < m; i++)
            {
                if (count[adj_a[i]] < 0.01 && count[adj_b[i]] < 0.01)
                {
                    draw_2_nodes_and_line(location[adj_a[i], 0], location[adj_a[i], 1], location[adj_b[i], 0], location[adj_b[i], 1], (int)(count[adj_a[i]] * 10000), (int)(count[adj_b[i]] * 10000), adj_a[i], adj_b[i], weight_array[i]);
                }
                else
                {
                    draw_2_nodes_and_line(location[adj_a[i], 0], location[adj_a[i], 1], location[adj_b[i], 0], location[adj_b[i], 1], (int)(count[adj_a[i]] * 100), (int)(count[adj_b[i]] * 100), adj_a[i], adj_b[i], weight_array[i]);
                }
            }

            //display centrality in a text box
            string str = "";
            for (int o = 0; o < n; o++)
            {
                str += "Node" + " " + o.ToString() + " --->" + count[o] + " | ";
            }
            textBox3.Text = str;
        }
       

        /*--------------------------------------Drawing Functions----------------------------------------------------*/
        void draw_circle(int x1, int y1, int r1, int node)
        {
            Pen p = new Pen(Color.PaleVioletRed, 2);
            this.CreateGraphics().DrawEllipse(p, x1, y1, r1, r1);
            this.CreateGraphics().FillEllipse(Brushes.PaleVioletRed, x1, y1, r1, r1);
            this.CreateGraphics().DrawString(node.ToString(), new Font("Tahoma", 10), Brushes.Black, x1, y1);
           
        }
        void draw_line(int x1, int y1, int x2, int y2, int weight)
        {
            Pen p = new Pen(Color.PaleGoldenrod, 5);
            this.CreateGraphics().DrawLine(p, x1, y1, x2, y2);
            this.CreateGraphics().DrawString(weight.ToString(), new Font("Tahoma", 10), Brushes.Black, ((x1 + x2) / 2) - 20, ((y1 + y2) / 2));

        }
        void draw_2_nodes_and_line(int num_1, int num_2, int num_3, int num_4, int r1, int r2, int node1, int node2, int weight)
        {
            draw_line(num_1 + 10, num_2 + 10, num_3 + 10, num_4 + 10, weight);
            draw_circle(num_1, num_2, r1, node1);
            draw_circle(num_3, num_4, r2, node2);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        /*-----------------------------------Dijkstra's Algorithm-----------------------------------------------*/
        int minDistance(int[] dist, bool[] sptset, int V)
        {
            // Initialize min value

            int min = int.MaxValue, min_index = 0;

            for (int v = 0; v < V; v++)
                if (sptset[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        float dijkstra(int[,] graph, int src, int V)
        {
            float sum_of_dist = 0;
            int[] dist = new int[V]; 
            bool[] sptSet = new bool[V]; 

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }
            // Distance of source vertex from itself is always 0
            dist[src] = 0;

            // Find shortest path for all vertices
            for (int count = 0; count < V - 1; count++)
            {
                int u = minDistance(dist, sptSet, V);

                // Mark the picked vertex as processed
                sptSet[u] = true;

                // Update dist value of the adjacent vertices of the picked vertex.
                for (int v = 0; v < V; v++)
                {
                    if (!sptSet[v] && Convert.ToBoolean(graph[u, v]) && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }
                }
            }
            

            for (int i = 0; i < V; i++)
            {
                sum_of_dist = sum_of_dist + dist[i];
            }

            return sum_of_dist;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /*----------------------------------------------------------------------------------*/

    }
}
