   M S B A M L   `   `   `  ????I  EFurnitureSales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FurnitureSales.PagesFurnitureSales.Pages  5      4    .FurnitureSales.Pages.CreateUpdateContractsPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:FurnitureSales.Pages     5        N? Title$  CreateUpdateContractsPage??5	       N? 
Background
 ?????.??5      ? -   5        $??ContractsGrid??5       ? ShowGridLines .   ? RowDefinitions 5   
   ?? 5      $??70 ?6   6*   ?? 5      6    ? ColumnDefinitions 5   
   ?? 5      6"   ?? 5      6!   ?? 5      6!   ?? 5      6!   .+?5   
   ?? -   5        $??CBBuyers??5      $??1??6#   $??0??63   $??20,11,30,11q?6@   $y?Hidden=?6U   ?? 5   
   $`??ZНиже выберите нужные товары и укажите количество??6   $??0??6K   $??1??6X   $??3??6h   $??Center=?6|   $??
0,0,-170,0q?6?   $??Center=?6?   $??16(?6?   ?? 5   
   $4??.Дата исполнения договора??6   $
??15,0q?63   $??Center=?6A   $
??Left=?6\   (  "System.Windows.Controls.DatePicker  5   
   -   5        $??DueDate??5      $??0??6%   $??0??62   
???   ?$??13,10q?6V   ?? 5   
   -   5        $??AddTypes??5      $??+??6!   $	??150??6.   $??10q?6Q   $	??100??6]   $??1??6l   $??1??6|   $??40??6?   $??Bottom=?6?   ?? 5   
   -   5        $??butAddToDataBase??5      $??Add contract??6)   $	??150??6A   $??10q?6l   $	??100??6x   $??2??6?   $??1??6?   $??40??6?   $??Bottom=?6?   $??Center=?6?   5      5      