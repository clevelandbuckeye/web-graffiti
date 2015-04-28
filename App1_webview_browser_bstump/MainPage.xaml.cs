using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Web.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;

namespace App1_webview_browser_bstump
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TagGrid_ManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
        {
            e.Handled = true;
            if (moveAroundThings)
            {
                _initCanLeft = (double)(AWebBrowserwebview1 as UIElement).GetValue(Canvas.LeftProperty);
                _initCanTop = (double)(AWebBrowserwebview1 as UIElement).GetValue(Canvas.TopProperty);
            }
        }

        private void TagGrid_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void TagGrid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            e.Handled = true;
        }
        double _initCanLeft;
        double _initCanTop;

        private void TagGrid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (!moveAroundThings) return;
            var newCanLeft = e.Cumulative.Translation.X + _initCanLeft;
            var newCanTop = e.Cumulative.Translation.Y + _initCanTop;
            var did = AWebBrowserwebview1 as UIElement;
            Canvas.SetLeft(did, newCanLeft);
            Canvas.SetTop(did, newCanTop);
            var did1 = ARectangleBrowser as UIElement;
            Canvas.SetLeft(did1, newCanLeft);
            Canvas.SetTop(did1, newCanTop);

            //add scaling objects too
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //AWebBrowserwebview1.IsHitTestVisible = true;
            //ASillyGridConShade.IsHitTestVisible = true;
            moveAroundThings = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //AWebBrowserwebview1.IsHitTestVisible = true;
            moveAroundThings = false;
            //ASillyGridConShade.IsHitTestVisible = false;
        }
        bool moveAroundThings = false;

        private void TagGrid_ManipulationStarting2(object sender, ManipulationStartingRoutedEventArgs e)
        {
            e.Handled = true;
            if (moveAroundThings)
            {
                _initCanLeft2 = (double)(AWebBrowserwebview2 as UIElement).GetValue(Canvas.LeftProperty);
                _initCanTop2 = (double)(AWebBrowserwebview2 as UIElement).GetValue(Canvas.TopProperty);
            }
        }

        private void TagGrid_ManipulationStarted2(object sender, ManipulationStartedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void TagGrid_ManipulationCompleted2(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            e.Handled = true;
        }
        double _initCanLeft2;
        double _initCanTop2;

        private void TagGrid_ManipulationDelta2(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (!moveAroundThings) return;
            var newCanLeft = e.Cumulative.Translation.X + _initCanLeft2;
            var newCanTop = e.Cumulative.Translation.Y + _initCanTop2;
            var did = AWebBrowserwebview2 as UIElement;
            Canvas.SetLeft(did, newCanLeft);
            Canvas.SetTop(did, newCanTop);
            var did1 = ARectangleBrowser2 as UIElement;
            Canvas.SetLeft(did1, newCanLeft);
            Canvas.SetTop(did1, newCanTop);

            //add scaling objects too
        }
        bool sendthere12 = false;
        private void CheckBox_Checked2(object sender, RoutedEventArgs e)
        {
            sendthere12 = true;
        }

        private void CheckBox_Unchecked2(object sender, RoutedEventArgs e)
        {
            sendthere12 = false;
        }
        bool stupidWebviewLatch = false;
        private void AWebBrowserwebview1_NavigationStarting1(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            if (sendthere12)
            {
                args.Cancel = true;
                //AWebBrowserwebview2.Navigate(args.Uri);
                string ua = "Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X)" + "AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25";
                Uri targetUri = (args.Uri);
                HttpRequestMessage hrm = new HttpRequestMessage(HttpMethod.Get, targetUri);
                hrm.Headers.Add("User-Agent", ua);
                AWebBrowserwebview2.NavigateWithHttpRequestMessage(hrm);
            }
            else
            {
                if (!stupidWebviewLatch)
                {
                    stupidWebviewLatch = true;
                    args.Cancel = true;
                    //AWebBrowserwebview2.Navigate(args.Uri);
                    string ua = "Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X)" + "AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25";
                    Uri targetUri = (args.Uri);
                    HttpRequestMessage hrm = new HttpRequestMessage(HttpMethod.Get, targetUri);
                    hrm.Headers.Add("User-Agent", ua);
                    try
                    {
                        AWebBrowserwebview1.NavigateWithHttpRequestMessage(hrm);

                    }
                    catch { }
                }
                else
                {
                    stupidWebviewLatch = false;
                }
            }
        }
        bool check3 = false;
        private void CheckBox_Unchecked3(object sender, RoutedEventArgs e)
        {
            check3 = false;
        }

        private void CheckBox_Checked3(object sender, RoutedEventArgs e)
        {
            check3 = true;
        }
        private void TagGrid_ManipulationStarting23(object sender, ManipulationStartingRoutedEventArgs e)
        {
            e.Handled = true;
            if (moveAroundThings)
            {
                _initCanLeft23 = (double)(AWebBrowserwebview23 as UIElement).GetValue(Canvas.LeftProperty);
                _initCanTop23 = (double)(AWebBrowserwebview23 as UIElement).GetValue(Canvas.TopProperty);
            }
        }

        private void TagGrid_ManipulationStarted23(object sender, ManipulationStartedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void TagGrid_ManipulationCompleted23(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            e.Handled = true;
        }
        double _initCanLeft23;
        double _initCanTop23;

        private void TagGrid_ManipulationDelta23(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (!moveAroundThings) return;
            var newCanLeft23 = e.Cumulative.Translation.X + _initCanLeft23;
            var newCanTop23 = e.Cumulative.Translation.Y + _initCanTop23;
            var did = AWebBrowserwebview23 as UIElement;
            Canvas.SetLeft(did, newCanLeft23);
            Canvas.SetTop(did, newCanTop23);
            var did1 = ARectangleBrowser23 as UIElement;
            Canvas.SetLeft(did1, newCanLeft23);
            Canvas.SetTop(did1, newCanTop23);

            //add scaling objects too
        }
        bool stupidWebviewLatch2 = false;
        private void AWebBrowserwebview2_NavigationStarting2(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            if (check3)
            {
                args.Cancel = true;
                AWebBrowserwebview23.Navigate(args.Uri);//change from = to ( ) if can do
                string ua = "Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X)" + "AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25";
                Uri targetUri = (args.Uri);
                HttpRequestMessage hrm = new HttpRequestMessage(HttpMethod.Get, targetUri);
                hrm.Headers.Add("User-Agent", ua);
                AWebBrowserwebview23.NavigateWithHttpRequestMessage(hrm);
            }
            else
            {
                if (stupidWebviewLatch2)
                {
                    stupidWebviewLatch2 = true;
                    args.Cancel = true;
                    //AWebBrowserwebview2.Navigate(args.Uri);
                    string ua = "Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X)" + "AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25";
                    Uri targetUri = (args.Uri);
                    HttpRequestMessage hrm = new HttpRequestMessage(HttpMethod.Get, targetUri);
                    hrm.Headers.Add("User-Agent", ua);
                    AWebBrowserwebview2.NavigateWithHttpRequestMessage(hrm);
                }
                else
                {
                    stupidWebviewLatch2 = false; //modifier touch move URL from webview 1 to webview 2. press button in corner with one hand, then second
                    //so position one is: suppose bottom left modifier area. press and hold or modify/check. then. 2nd part of gesture is 
                    //timeing could be used to make this gesture a one-pointer gesture. click, click, click....
                    //anyhow the gesture is one fing on button hold, release when 2nd gesture done. when 2nd gesture is drag from one window to the next
                    //the url will transfer from the first iwndow to the second
                    //bot left tap + right-hand (these are right-handed gestures i suppose) "drag drop" url from one window to the next.
                    //if no second window a new window can be created. sizez not determied and dynamic C# code generation fo the xaml and yeah, yeah, , ..., not ready
                }
            }
        }

        private void AWebBrowserwebview1_Loaded(object sender, RoutedEventArgs e)
        {
            stupidWebviewLatch = true;
            //args.Cancel = true;
            //AWebBrowserwebview2.Navigate(args.Uri);
            string ua = "Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X)" + "AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25";
            Uri targetUri = new Uri("http://www.bing.com");
            HttpRequestMessage hrm = new HttpRequestMessage(HttpMethod.Get, targetUri);
            hrm.Headers.Add("User-Agent", ua);
            try
            {
                AWebBrowserwebview1.NavigateWithHttpRequestMessage(hrm);

            }
            catch { }
        } //automate this snippet some way 

        private int _middleRow = 1;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string callername = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(callername));
            }
        }
        public int BindingMiddleRow
        {
            get
            {
                if (GridHashtagShape != null && GridHashtagShape.RowDefinitions != null)
                {
                    return GridHashtagShape.RowDefinitions.Count;
                }
                return _middleRow;
            }
            set
            {
                _middleRow = value;
                OnPropertyChanged();
            }
        }

        private int middleCol;
        public int BindingMiddleColumn
        {
            get
            {
                if (GridHashtagShape != null && GridHashtagShape.ColumnDefinitions != null)
                {
                    return GridHashtagShape.ColumnDefinitions.Count;
                }
                return middleCol;
            }
            set { middleCol = value; }
        }

        private void GridHashtagShape_Loaded(object sender, RoutedEventArgs e)
        {
            Grid senderGrid = sender as Grid;
            if (senderGrid == null) return;

            if (senderGrid.ColumnDefinitions != null && senderGrid.RowDefinitions != null)
            {
                //find cleaner way to code this
                for (int col = 0; col < senderGrid.ColumnDefinitions.Count; col++)
                {
                    for (int row = 0; row < senderGrid.RowDefinitions.Count; row++)
                    {
                        var newGridCR19 = getGridObject19(senderGrid, row, col);
                        setEventHandlers(newGridCR19); //could hotel room number 10,000,000+1 be a unique number for location in spc2t?
                        senderGrid.Children.Add(newGridCR19);
                        //addDebugIO(newGridCR19, row, col);
                        //AddTextBoxToEmptyRowCol(newGridCR19); //other universe is time time is extra universe exists in space
                        //AddTextBoxToEmptyRowCol(newGridCR19);
                        AddChildrenTonewGridCR19(newGridCR19);
                    }
                }
            }
        }

        private void AddChildrenTonewGridCR19(Grid newGridCR19)
        {
            makeGridHashTagShape(newGridCR19);
            //find cleaner way to code this
            for (int col = 0; col < newGridCR19.ColumnDefinitions.Count; col++)
            {
                for (int row = 0; row < newGridCR19.RowDefinitions.Count; row++)
                {
                    var newGridCR192 = getGridObject19(newGridCR19, row, col);
                    newGridCR19.Children.Add(newGridCR192);
                    //addDebugIO(newGridCR192, row, col);
                    //AddTextBoxToEmptyRowCol(newg
                    AddTextBoxToEmptyRowCol(newGridCR192, row, col);
                    //AddChildrenTonewGridCR19(newGridCR19);
                    //setEventHandlers(newGridCR192); //could hotel room number 10,000,000+1 be a unique number for location in spc2t?
                }
            }





            //addDebugIO(newGridCR19);
            //create quick style grid
            //makeGridHashTagShape(newGridCR19);
            //add1Debug(newGridCR19);
            //addDebugIO(newGridCR19, 4);
        }

        private void setEventHandlers(Grid newGridCR19)
        {
            newGridCR19.Loaded += NewGridCR19_Loaded;
            newGridCR19.PointerMoved += NewGridCR19_PointerMoved;
        }

        private Grid getGridObject19(Grid senderGrid, int row, int col)
        {
            //////////throw new NotImplementedException();

            Grid newGridCR19 = new Grid();
            newGridCR19.SetValue(Grid.RowProperty, row);
            newGridCR19.SetValue(Grid.ColumnProperty, col);
            newGridCR19.Background = new SolidColorBrush(Colors.AliceBlue);
            newGridCR19.Margin = new Thickness(4);
            newGridCR19.HorizontalAlignment = HorizontalAlignment.Stretch;
            newGridCR19.VerticalAlignment = VerticalAlignment.Stretch;
            return newGridCR19;
        }
        public static void makeGridHashTagShape(Grid grid)
        {
            //bad method signature
            makeGridHashTagShape(grid, 3, 3);
        }
        //bad method signature
        /// <summary>
        /// grid goes in, same grid goes out. grid gets extra rows and columns, grid items are NOT reset. null safe #nullnew
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static Grid makeGridHashTagShape(Grid grid, int row, int col)
        {
            //bad method signature
            if (grid == null)
            {
                grid = new Grid();
            }
            for (int r = 0; r < row; r++)
            {
                //bad method signature
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int c = 0; c < col; c++)
            {
                //bad method signature
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
            return grid;
        }
        /// <summary>
        /// returns 0 if no children or if none found
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int findFirstEmptyRow(Grid grid)
        {
            for (int row = 0; row < grid.RowDefinitions.Count; row++)
            {
                if (grid.Children.Any((x) => (int)x.GetValue(Grid.RowProperty) == row))
                {
                    return row;
                }
            }
            return 0;
        }
        public static int findFirstEmptyCol(Grid grid)
        {
            for (int col = 0; col < grid.RowDefinitions.Count; col++)
            {
                if (grid.Children.Any((x) => (int)x.GetValue(Grid.ColumnProperty) == col))
                {
                    return col;
                }
            }
            return 0;
        }
        public static bool hasEmptyCol(Grid grid)
        {
            if (grid.RowDefinitions.Count > grid.Children.Count)
            {
                return true;
            }
            for (int col = 0; col < grid.RowDefinitions.Count; col++)
            {
                if (grid.Children.Any((x) => (int)x.GetValue(Grid.ColumnProperty) == col))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool hasEmptyRow(Grid grid)
        {
            if (grid.ColumnDefinitions.Count > grid.Children.Count)
            {
                return true;
            }
            for (int row = 0; row < grid.RowDefinitions.Count; row++)
            {
                if (grid.Children.Any((x) => (int)x.GetValue(Grid.RowProperty) == row))
                {
                    return true;
                }
            }
            return false;
        }
        public static TextBox AddTextBoxToEmptyRowCol(Grid grid)
        {
            var newTextBox = new TextBox();
            var row = findFirstEmptyRow(grid);
            var col = findFirstEmptyCol(grid);
            newTextBox.SetValue(Grid.RowProperty, row);
            newTextBox.SetValue(Grid.ColumnProperty, col);

            newTextBox.Text = string.Format("row:{0},col:{1}", row, col); //@BrianG North Pine + GreenNorth Pine + every atom is producing a big bang. different speed. crush-use-divide.

            grid.Children.Add(newTextBox);
            return newTextBox;
        }
        public static TextBox AddTextBoxToEmptyRowCol(Grid grid, int row, int col)
        {
            var newTextBox = new TextBox();
            //var row = findFirstEmptyRow(grid);
            //var col = findFirstEmptyCol(grid);
            newTextBox.SetValue(Grid.RowProperty, row);
            newTextBox.SetValue(Grid.ColumnProperty, col);

            newTextBox.Text = string.Format("row:{0},col:{1}", row, col); //@BrianG North Pine + GreenNorth Pine + every atom is producing a big bang. different speed. crush-use-divide.

            grid.Children.Add(newTextBox);
            return newTextBox;
        }
        public static void add1Debug(Grid newGridCR19)
        {
            addDebugIO(newGridCR19, 1);
        }
        public static void addDebugIO(Grid newGridCR19)
        {
            //throw new NotImplementedException(); //show where the sun will be in infinite years
            while (hasEmptyCol(newGridCR19) && hasEmptyRow(newGridCR19))
            {
                var row = findFirstEmptyRow(newGridCR19);
                var col = findFirstEmptyCol(newGridCR19);

                addDebugIO(newGridCR19, row, col);
            }
        }
        public static void addDebugIO(Grid newGridCR19, int numToAdd)
        {
            //pass by copy I think
            //throw new NotImplementedException(); //show where the sun will be in infinite years
            while (hasEmptyCol(newGridCR19) && hasEmptyRow(newGridCR19) && numToAdd-- > 0)
            {
                var row = findFirstEmptyRow(newGridCR19);
                var col = findFirstEmptyCol(newGridCR19);

                addDebugIO(newGridCR19, row, col);
            }
        }

        public static void addDebugIO(Grid newGridCR19, int row, int col)
        {
            TextBox editbox = new TextBox();
            //editbox.SetValue(Grid.RowProperty, row);
            //editbox.SetValue(Grid.ColumnProperty, col);
            editbox.Text = String.Format("row:{0},col:{1}", row, col);
            //stackpanel maybe
            newGridCR19.Children.Add(editbox);
        } 

        private void NewGridCR19_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void NewGridCR19_Loaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
