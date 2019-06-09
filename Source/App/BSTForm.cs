using App.Comparer;
using App.Model;
using BinarySearchTree;
using BinarySearchTree.Counter;
using BinarySearchTree.Iterator;
using BinarySearchTree.Model;
using BinarySearchTree.Searcher;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

/** 
 * @Author: Khoa Nguyen Van
 *  @Contact: khoavantdt@gmail.com
 */
namespace App
{
    public partial class BSTForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        // Tree type
        private const int INTEGER_TREE = 0;
        private const int STRING_TREE = 1;

        private BST<GraphicNodeValue> BST;
        private BST<GraphicNodeValue> BSTStr;
        private BSTGraphic<GraphicNodeValue> _g = new BSTGraphic<GraphicNodeValue>();
        private BSTGraphic<GraphicNodeValue> _gStr = new BSTGraphic<GraphicNodeValue>();
        private int _treeType = STRING_TREE;
        private const int MAX_INPUT = 3;
        // Message type
        private const int INFO_MSG = 100;
        private const int ERR_MSG = 101;
        private const int WARNING_MSG = 102;

        public BSTForm()
        {
            InitializeComponent();
            InitData(INTEGER_TREE);
            InitData(STRING_TREE);
            HandleEvent();
            DrawTree();
        }
        private void HandleEvent()
        {
            repoTbSearch.KeyDown += repoTbSearch_KeyDown;
            repoTbInsert.KeyDown += repoTbInsert_KeyDown;
            repoTbDel.KeyDown += repoTbDel_KeyDown;
            repoTbPathLength.KeyDown += repoTbPathLength_KeyDown;
        }
        private void InitData(int treeType)
        {
            if (treeType == INTEGER_TREE)
            {
                int[] a = { 500, 200, 250, 700};
                List<GraphicNodeValue> nodes = new List<GraphicNodeValue>();
                for (int i = 0; i < a.Length; i++)
                {
                    nodes.Add(new IntegerGraphicNodeValue(a[i]));
                }
                BST = new BST<GraphicNodeValue>(nodes, new GraphicNodeComparer());
            }
            else
            {
                string[] s = {"lov", "you", "so", "muc" };
                List<GraphicNodeValue> sNodes = new List<GraphicNodeValue>();
                for (int i = 0; i < s.Length; i++)
                {
                    sNodes.Add(new StringGraphicNodeValue(s[i]));
                }
                BSTStr = new BST<GraphicNodeValue>(sNodes, new GraphicNodeComparer());
            }
        }
        /// <summary>
        /// Random a node which could be success inserted to the tree
        /// </summary>
        private GraphicNodeValue RandANode(int treeType)
        {
            GraphicNodeValue randNode = null;
            if (treeType == INTEGER_TREE)
            {
                int iVal;
                Random rand = new Random();
                do
                {
                    iVal = rand.Next(-100, 1000); // Random an integer with 3 digits
                    randNode = new IntegerGraphicNodeValue(iVal);
                } while (!BST.SearchNodeValue(randNode).IsEmpty());
            }
            else
            {
                string s = "";
                do
                {
                    string path = Path.GetRandomFileName();
                    path = path.Replace(".", ""); // Remove period.
                    s = path.Substring(0, 3);  // Return 3 character string
                    randNode = new StringGraphicNodeValue(s);
                } while (!BSTStr.SearchNodeValue(randNode).IsEmpty());
            }
            return randNode;
        }
        private void DrawTree()
        {
            int center;
            if (_treeType == INTEGER_TREE)
                pbTree.Image = _g.DrawNode(BST.RootNode, out center);
            else
                pbTree.Image = _gStr.DrawNode(BSTStr.RootNode, out center);
        }
        /// <summary>
        /// Validate user input
        /// </summary>
        /// <param name="format">Tree type</param>
        private int ValidateInput(String input, int format)
        {
            // Null
            if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input))
                return -1;
            // Format incorrect
            if (format == INTEGER_TREE)
            {
                int i;
                if (!int.TryParse(input, out i))
                    return -2;
            }
            // More than max length
            if (input.Length > MAX_INPUT)
                return -3;
            return 0;
        }
        /// <summary>
        /// Notify message if error occured
        /// </summary>
        private bool ValidateInputWithUI(String input, int format)
        {
            int err = ValidateInput(input, format);
            String message = "";
            switch (err)
            {
                case -1:
                    message = "Empty input. Please enter value!";
                    break;
                case -2:
                    message = "Incorrect input format. Should be enter an integer!";
                    break;
                case -3:
                    message = "Incorrect input. The entered value should be less than 3 characters!";
                    break;
                default:
                    return false;
            }

            ShowMessage(message, "NOTICE", ERR_MSG);
            return true;
        }
        private void ShowMessage(String content, String title, int type)
        {
            switch (type)
            {
                case ERR_MSG:
                    MessageBox.Show(content, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    break;
                case WARNING_MSG:
                    MessageBox.Show(content, title, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    break;
                default:
                    MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }


        #region HOME tab
        /// <summary>
        /// Convert Node value to string
        /// </summary>
        private string GetValue(Node<GraphicNodeValue> node)
        {
            if (node == null || node.IsEmpty())
                return "null";
            return ((ValuableNode<GraphicNodeValue>)node).Value.ConvertToString();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void cbInt_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cbInt.Checked)
            {
                _treeType = INTEGER_TREE;
                BSTStr.Clear();
                DrawTree();
            }
        }

        private void cbString_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cbString.Checked)
            {
                _treeType = STRING_TREE;
                BST.Clear();
                DrawTree();
            }
                
        }


        #region Editting
        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pbTree.Image != null)
            {
                String s = "Your current drawing will be lost. Are your sure?";
                DialogResult dg = MessageBox.Show(s, "NOTICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == System.Windows.Forms.DialogResult.Yes)
                {
                    if (_treeType == INTEGER_TREE)
                        BST.Clear();
                    else
                        BSTStr.Clear();
                    DrawTree();
                }
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pbTree.Image == null)
            {
                MessageBox.Show("Cannot save an empty tree. Drawing something, please!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                const double quality = 1;
                var d = new SaveFileDialog { Filter = @"jpeg files|*.jpg" };
                try
                {
                    if (d.ShowDialog() != DialogResult.OK)
                        return;
                    var bmp = pbTree.Image;
                    var qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality,
                                                                         (long)(quality * 75));
                    // Jpeg image codec
                    var jpegCodec = GetEncoderInfo("image/jpeg");
                    if (jpegCodec == null)
                        return;
                    var encoderParams = new EncoderParameters(1);
                    encoderParams.Param[0] = qualityParam;
                    bmp.Save(d.FileName, jpegCodec, encoderParams);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        public ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            var codecs = ImageCodecInfo.GetImageEncoders();
            // Find the correct image codec
            return codecs.FirstOrDefault(t => t.MimeType == mimeType);
        }

       


        #endregion

        #region Search value
        private void SearchValue()
        {
            String input = tbValSearch.EditValue.ToString();
            if (!ValidateInputWithUI(input, _treeType))
            {
                Node<GraphicNodeValue> node = null;
                if (_treeType == INTEGER_TREE)
                {
                    node = BST.SearchNodeValue(new IntegerGraphicNodeValue(int.Parse(input)));
                }
                else
                {
                    node = BSTStr.SearchNodeValue(new StringGraphicNodeValue(input));
                }

                String s = "";
                if (!node.IsEmpty())
                {
                    s += "Node = " + GetValue(node) + "\n";
                    s += "  - Parent = " + GetValue(node.Parent) + "\n";
                    ValuableNode<GraphicNodeValue> valNode = (ValuableNode<GraphicNodeValue>)node;
                    s += "  - Left = " + GetValue(valNode.Left) + "\n";
                    s += "  - Right = " + GetValue(valNode.Right);
                }
                else
                    s = "[" + input + "]" + " " + "doesn't exist in Tree";
                ShowMessage(s, "SEARCH RESULT", INFO_MSG);
            }
        }
        void repoTbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbValSearch.Manager.ActiveEditItemLink.PostEditor(); // Important. tbValSearch.EditValue will be null while it editor is editing. It updates tbValSearch.EditValue from it current repoTbSearch editor
                SearchValue();
            }
        }
        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchValue();
        }
        #endregion

        #region Insert
        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String input = tbInsert.EditValue.ToString();
            if (!ValidateInputWithUI(input, _treeType))
            {
                if (_treeType == INTEGER_TREE)
                {
                    int val = int.Parse(tbInsert.EditValue.ToString());
                    BST.Insert(new IntegerGraphicNodeValue(val));
                }
                else
                {
                    BSTStr.Insert(new StringGraphicNodeValue(tbInsert.EditValue.ToString()));
                }

                DrawTree();
            }
        }
        void repoTbInsert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbInsert.Manager.ActiveEditItemLink.PostEditor();
                btnInsert_ItemClick(btnInsert, new DevExpress.XtraBars.ItemClickEventArgs(null, null));
            }
        }
        private void btnRndInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GraphicNodeValue rndNode = RandANode(_treeType);
            tbInsert.EditValue = rndNode.ConvertToString();
            if (_treeType == INTEGER_TREE)
                BST.Insert(rndNode);
            else
                BSTStr.Insert(rndNode);
            DrawTree();
        }
        #endregion 

        #region Delete value
        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String input = tbDel.EditValue.ToString();
            if (!ValidateInputWithUI(input, _treeType))
            {
                if (_treeType == INTEGER_TREE)
                {
                    int val = int.Parse(tbDel.EditValue.ToString());
                    BST.Delete(new IntegerGraphicNodeValue(val));
                }
                else
                    BSTStr.Delete(new StringGraphicNodeValue(tbDel.EditValue.ToString()));

                DrawTree();
            }
        }
        void repoTbDel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbDel.Manager.ActiveEditItemLink.PostEditor();
                btnDel_ItemClick(btnDel, new DevExpress.XtraBars.ItemClickEventArgs(null, null));
            }
        }
        #endregion

        #region Get path length
        private void btnPathLength_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String input = tbPathLength.EditValue.ToString();
            if (!ValidateInputWithUI(input, _treeType))
            {
                int length;
                if (_treeType == INTEGER_TREE)
                    length = BST.GetPathLengthToNodeValue(new IntegerGraphicNodeValue(int.Parse(input)));
                else
                    length = BSTStr.GetPathLengthToNodeValue(new StringGraphicNodeValue(input));

                String res = "";
                if (length == -1)
                    res += "[" + input + "] doesn't exist in Tree\n";
                res += "Path length from [Root] to " + "[" + input + "]" + " is " + length.ToString();

                MessageBox.Show(res, "GET PATH LENGTH", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void repoTbPathLength_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPathLength.Manager.ActiveEditItemLink.PostEditor();
                btnPathLength_ItemClick(btnPathLength, new DevExpress.XtraBars.ItemClickEventArgs(null, null));
            }
        }

        #endregion

        

        #endregion


        #region TREE INFO Tab
        private string PreOrderTraversal()
        {
            string res = "PREORDER\n";
            ArrayForwardIterator<GraphicNodeValue> iterator;
            if (_treeType == INTEGER_TREE)
                iterator = (ArrayForwardIterator<GraphicNodeValue>)BST.PreOrderTraversing(new ArrayForwardIteratorBounding<GraphicNodeValue>());
            else
                iterator = (ArrayForwardIterator<GraphicNodeValue>)BSTStr.PreOrderTraversing(new ArrayForwardIteratorBounding<GraphicNodeValue>());

            for (iterator.First(); !iterator.IsDone(); iterator.Next())
                res += "[" + iterator.Current().ConvertToString() + "]" + " ";
            return res;
        }
        private string InOrderTraversal()
        {
            string res = "INORDER\n";
            ArrayForwardIterator<GraphicNodeValue> iterator;
            if (_treeType == INTEGER_TREE)
                iterator = (ArrayForwardIterator<GraphicNodeValue>)BST.InOrderTraversing(new ArrayForwardIteratorBounding<GraphicNodeValue>());
            else
                iterator = (ArrayForwardIterator<GraphicNodeValue>)BSTStr.InOrderTraversing(new ArrayForwardIteratorBounding<GraphicNodeValue>());

            for (iterator.First(); !iterator.IsDone(); iterator.Next())
                res += "[" + iterator.Current().ConvertToString() + "]" + " ";
            return res;
        }
        private string PostOrderTraversal()
        {
            string res = "POSTORDER\n";
            ArrayForwardIterator<GraphicNodeValue> iterator;
            if (_treeType == INTEGER_TREE)
                iterator = (ArrayForwardIterator<GraphicNodeValue>)BST.PostOrderTraversing(new ArrayForwardIteratorBounding<GraphicNodeValue>());
            else
                iterator = (ArrayForwardIterator<GraphicNodeValue>)BSTStr.PostOrderTraversing(new ArrayForwardIteratorBounding<GraphicNodeValue>());

            for (iterator.First(); !iterator.IsDone(); iterator.Next())
                res += "[" + iterator.Current().ConvertToString() + "]" + " ";
            return res;
        }
        private void btnPreorder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowMessage(PreOrderTraversal(), "TRAVERSAL RESULT", INFO_MSG);
        }
        private void btnInorder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowMessage(InOrderTraversal(), "TRAVERSAL RESULT", INFO_MSG);
        }

        private void btnPostorder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowMessage(PostOrderTraversal(), "TRAVERSAL RESULT", INFO_MSG);
        }

        private void btnAllOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowMessage(PreOrderTraversal() + "\n" + InOrderTraversal() + "\n" + PostOrderTraversal(), "TRAVERSAL RESULT", INFO_MSG);
        }

        private void btnGetHeight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int height = _treeType == INTEGER_TREE ? BST.GetHeight() : BSTStr.GetHeight();
            ShowMessage("HEIGHT: " + height.ToString(), "TREE HEIGHT", INFO_MSG);
        }
        #endregion

        

        #region SEARCH Tab
        private void btnNodeMin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Node<GraphicNodeValue> node = _treeType == INTEGER_TREE ? BST.SearchNodeSatisfy(new NodeMinSearcher<GraphicNodeValue>())
                                                                    : BSTStr.SearchNodeSatisfy(new NodeMinSearcher<GraphicNodeValue>());
            ShowMessage("NODE MIN: " + GetValue(node), "NODE MIN", INFO_MSG);
        }

        private void btnNodeRightMin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Node<GraphicNodeValue> node = _treeType == INTEGER_TREE ? BST.SearchNodeSatisfy(new NodeMinInRightChildSearcher<GraphicNodeValue>())
                                                                    : BSTStr.SearchNodeSatisfy(new NodeMinInRightChildSearcher<GraphicNodeValue>());
            ShowMessage("NODE MIN IN RIGHT CHILD: " + GetValue(node), "NODE MIN IN RIGHT CHILD", INFO_MSG);
        }

        private void btnNodeMax_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Node<GraphicNodeValue> node = _treeType == INTEGER_TREE ? BST.SearchNodeSatisfy(new NodeMaxSearcher<GraphicNodeValue>())
                                                                    : BSTStr.SearchNodeSatisfy(new NodeMaxSearcher<GraphicNodeValue>());
            ShowMessage("NODE MAX: " + GetValue(node), "NODE MAX", INFO_MSG);
        }

        private void btnNodeLeftMax_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Node<GraphicNodeValue> node = _treeType == INTEGER_TREE ? BST.SearchNodeSatisfy(new NodeMaxInLeftChildSearcher<GraphicNodeValue>())
                                                                    : BSTStr.SearchNodeSatisfy(new NodeMaxInLeftChildSearcher<GraphicNodeValue>());
            ShowMessage("NODE MAX IN LEFT CHILD: " + GetValue(node), "NODE MAX IN LEFT CHILD", INFO_MSG);
        }

        #endregion


        #region COUNT Tab
        private void btnNodeTotal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string res = _treeType == INTEGER_TREE ? BST.CountNodeSatisfy(new NodeTotalCounter<GraphicNodeValue>()).ToString()
                                                     : BSTStr.CountNodeSatisfy(new NodeTotalCounter<GraphicNodeValue>()).ToString();
            ShowMessage("Total node: " + res, "NODE COUTER", INFO_MSG);
        }
        private void btnLeaf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string leafs = _treeType == INTEGER_TREE ? BST.CountNodeSatisfy(new LeafCounter<GraphicNodeValue>()).ToString()
                                                     : BSTStr.CountNodeSatisfy(new LeafCounter<GraphicNodeValue>()).ToString();
            ShowMessage("Total leaf node: " + leafs, "NODE COUTER", INFO_MSG);
        }

        private void btnFullChilds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string res = _treeType == INTEGER_TREE ? BST.CountNodeSatisfy(new NodeFullChildsCounter<GraphicNodeValue>()).ToString()
                                                     : BSTStr.CountNodeSatisfy(new NodeFullChildsCounter<GraphicNodeValue>()).ToString();
            ShowMessage("Total node has full childs: " + res, "NODE COUTER", INFO_MSG);
        }

        private void btnLeftChildOnly_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string res = _treeType == INTEGER_TREE ? BST.CountNodeSatisfy(new NodeHasLeftChildOnlyCounter<GraphicNodeValue>()).ToString()
                                                     : BSTStr.CountNodeSatisfy(new NodeHasLeftChildOnlyCounter<GraphicNodeValue>()).ToString();
            ShowMessage("Total node has left child only: " + res, "NODE COUTER", INFO_MSG);
        }

        private void btnRightChildOnly_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string res = _treeType == INTEGER_TREE ? BST.CountNodeSatisfy(new NodeHasRightChildOnlyCounter<GraphicNodeValue>()).ToString()
                                                     : BSTStr.CountNodeSatisfy(new NodeHasRightChildOnlyCounter<GraphicNodeValue>()).ToString();
            ShowMessage("Total node has right child only: " + res, "NODE COUTER", INFO_MSG);
        }

        private void btn1Child_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string res = _treeType == INTEGER_TREE ? BST.CountNodeSatisfy(new NodeHasOneChildCounter<GraphicNodeValue>()).ToString()
                                                     : BSTStr.CountNodeSatisfy(new NodeHasOneChildCounter<GraphicNodeValue>()).ToString();
            ShowMessage("Total node has 1 child: " + res, "NODE COUTER", INFO_MSG);
        }

        private void btnEachFloor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<int> floor = _treeType == INTEGER_TREE ? BST.CountNodeInEachFloor() : BSTStr.CountNodeInEachFloor();
            string nodeFs = "";
            if (floor != null)
            {
                int i = 0;
                foreach (int item in floor)
                {
                    nodeFs += "[Floor" + i.ToString() + "]      " + item.ToString() + "\n";
                    ++i;
                }
            }
            ShowMessage("Count node in each floor: \n" + nodeFs, "NODE COUTER", INFO_MSG);
        }
        #endregion

        private void btnAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String s = "<[ DESIGN  PATTERN  PROJECT  2016 ]>\n" + 
                       "   BINARY SEARCH TREE FRAMEWORK\n\n\n" +
                       "                                                     ⒸCopyright\n" + 
                       "                                                     [Perl Team]\n";
            ShowMessage(s, "INFORMATION", INFO_MSG);
        }



        #region HELP Tab

        #endregion
    }
}
