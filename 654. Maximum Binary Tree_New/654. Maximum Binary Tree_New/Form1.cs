using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _654.Maximum_Binary_Tree_New
{
    public partial class Form1 : Form
    {
        public static int[] nums;
        public static bool GetResult = false;
        public static List<TreeNode> All_Node = new List<TreeNode>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nums = new int[] { 3, 2, 1, 6, 0, 5 };
            Method1_FindMax(new List<int[]> { nums });  //Method1
            //nums = Output.Select(int.Parse).ToArray();
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return Method1_FindMax(new List<int[]> { nums });  //Method1
        }
        static TreeNode Method1_FindMax(List<int[]> array_list)    //Start from the Max Value
        {
            GetResult = true;   //Set true for every loop, if array not null, turn false
            int Temp_Max_Idx;
            List<int[]> temp_array = new List<int[]>();
            //int Temp_Max_Val;
            //int[] Temp_Array;
            foreach (int[] array in array_list)
            {
                if (array.Length != 0)
                {
                    Temp_Max_Idx = Array.IndexOf(array, array.Max());    // Find Max Value and it's Addr in array
                    int[] Left_New_List = array.Where(val => Array.IndexOf(array, val) < Temp_Max_Idx).ToArray();
                    int[] Right_New_List = array.Where(val => Array.IndexOf(array, val) > Temp_Max_Idx).ToArray();

                    TreeNode NewNode = new TreeNode(array[Temp_Max_Idx]);
                    NewNode.left = Method1_FindMax(new List<int[]> { Left_New_List });
                    NewNode.right = Method1_FindMax(new List<int[]> { Right_New_List });

                    //if (Left_New_List.Length != 0 || Right_New_List.Length != 0)
                    //{
                    //    temp_array.Add(Left_New_List);
                    //    temp_array.Add(Right_New_List);
                    //}
                    All_Node.Add(NewNode);                    
                    GetResult = false;
                    return NewNode;

                }
                else
                {
                    return null;
                }

            }
            if (GetResult == true) return null;
            //Method1_FindMax(temp_array);     //Left,Right Recursion
                                             //return null;
            return new TreeNode(-1);
        }
    }
}
