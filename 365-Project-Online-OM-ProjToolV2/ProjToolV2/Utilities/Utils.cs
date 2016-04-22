/*
 * Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT license.
 * See LICENSE in the project root for license information.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SP = Microsoft.SharePoint.Client;

namespace ProjToolV2
{
    /// <summary>
    /// Common class that contains helper extension methods for client object.
    /// </summary>
    public static class ClientExtension
    {
        /// <summary>
        /// Get value for a given property
        /// </summary>
        /// <param name="clientObject"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static string GetFieldValueAsString(this SP.ClientObject clientObject, PropertyInfo prop)
        {
            string fieldValue = string.Empty;

            if (clientObject?.ServerObjectIsNull == null || prop == null)
            {
                return fieldValue;
            }
            try
            {
                return prop.GetValue(clientObject) as string;
            }
            catch (TargetInvocationException)
            {
                return fieldValue;
            }
        }

        public static string GetFieldValueAsString(this SP.ClientObject clientObject, string fieldName)
        {
            PropertyInfo prop = clientObject.GetType().GetProperties().FirstOrDefault(s => s.Name == fieldName);
            return clientObject.GetFieldValueAsString(prop);
        }

        /// <summary>
        /// Function responsible to check whether the client object is Null
        /// </summary>
        /// <param name="clientObject"></param>
        /// <returns></returns>
        public static bool IsNull(this SP.ClientObject clientObject)
        {
            if (clientObject == null) return true;
            return clientObject.ServerObjectIsNull.HasValue && clientObject.ServerObjectIsNull.Value;
        }
    }

    /// <summary>
    /// Common functions and extensions for the UI controls.
    /// </summary>
    public static class ControlHelpers
    {
        /// <summary>
        /// Function responsible to perform action on the UI element from background thread.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="action"></param>
        public static void InvokeIfRequired<T>(this T control, Action<T> action) where T : ISynchronizeInvoke
        {
            if (control == null) return;
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action(control)), null);
            }
            else
            {
                action(control);
            }
        }

        /// <summary>
        /// Function responsible to center the listview text and bold it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ListViewDrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
            e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlDark), e.Bounds);

            using (Font headerFont = new Font("Helvetica", 10, FontStyle.Bold))
            {
                e.Graphics.DrawString(e.Header.Text, headerFont,
                    Brushes.Black, e.Bounds, sf);
            }
        }

        public static void ListViewDrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        public static void ListViewDrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /// <summary>
        /// Function responsible for auto resizing the listview values.
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="autoSizeColumnIndex"></param>
        public static void ResizeColumnHeaders(this ListView listView, int autoSizeColumnIndex = 0)
        {
            if (listView.View != View.Details || listView.Columns.Count <= 0 || autoSizeColumnIndex < 0)
            {
                return;
            }
            if (autoSizeColumnIndex >= listView.Columns.Count)
            {
                Log.WriteCritical(new SourceInfo(), "Column index out of range.");
                return;
            }

            int otherColumnsWidth = listView.Columns.Cast<ColumnHeader>()
                .Where(header => header.Index != autoSizeColumnIndex)
                .Select(header => header.Width).Sum();

            int autoSizeColumnWidth = listView.ClientRectangle.Width - otherColumnsWidth;

            if (listView.Columns[autoSizeColumnIndex].Width != autoSizeColumnWidth)
                listView.Columns[autoSizeColumnIndex].Width = autoSizeColumnWidth;
        }

        /// <summary>
        /// Function responsible to sort list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SortListView(object sender, ColumnClickEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.ListViewItemSorter == null)
            {
                ListViewColumnSorter columnSorter = new ListViewColumnSorter();
                lv.ListViewItemSorter = columnSorter;
                lv.Tag = columnSorter;
            }
            ListViewColumnSorter lvwColumnSorter = (ListViewColumnSorter)lv.Tag;
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lv.Sort();
        }
    }

    /// <summary>
    /// Commonly used extension methods on IEnumerable objects
    /// </summary>
    public static class EnumerableExtension
    {
        public static Random Randomizer = RandomEx.Random;

        public static List<T> PickRandom<T>(this IEnumerable<T> source, int numItems)
        {
            var values = source.ToList();

            //Return all items if the request is less than the available items
            if (numItems >= values.Count)
            {
                return values;
            }
            else
            {
                return values.OrderBy(x => Randomizer.Next()).Take(numItems).ToList();
            }
        }

        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.Shuffle().Take(1).Single();
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }
    }

    /// <summary>
    /// Common static methods for Random functionality.
    /// </summary>
    public static class RandomEx
    {
        public static Random Random = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// generates random string of length equal to the given number.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Random.NextDouble() + 65)));
                builder.Append(ch);
            }
            Log.WriteVerbose(new SourceInfo(), "Random String:{0}", builder.ToString());
            return builder.ToString();
        }
    }

    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int _columnToSort;

        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer _objectCompare;

        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder _orderOfSort;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            _columnToSort = 0;

            // Initialize the sort order to 'none'
            _orderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            _objectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                _orderOfSort = value;
            }
            get
            {
                return _orderOfSort;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                _columnToSort = value;
            }
            get
            {
                return _columnToSort;
            }
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            // Cast the objects to be compared to ListViewItem objects
            var listviewX = (ListViewItem)x;
            var listviewY = (ListViewItem)y;

            // Compare the two items
            if (listviewX.SubItems.Count <= _columnToSort &&
                    listviewY.SubItems.Count <= _columnToSort)
            {
                compareResult = _objectCompare.Compare(null, null);
            }
            else if (listviewX.SubItems.Count <= _columnToSort &&
                     listviewY.SubItems.Count > _columnToSort)
            {
                compareResult = _objectCompare.Compare(null, listviewY.SubItems[_columnToSort].Text.Trim());
            }
            else if (listviewX.SubItems.Count > _columnToSort && listviewY.SubItems.Count <= _columnToSort)
            {
                compareResult = _objectCompare.Compare(listviewX.SubItems[_columnToSort].Text.Trim(), null);
            }
            else
            {
                compareResult = _objectCompare.Compare(listviewX.SubItems[_columnToSort].Text.Trim(), listviewY.SubItems[_columnToSort].Text.Trim());
            }

            //var compareResult = _objectCompare.Compare(listviewX.SubItems[_columnToSort].Text, listviewY.SubItems[_columnToSort].Text);

            // Calculate correct return value based on object comparison
            if (_orderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (_orderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }
    }
}