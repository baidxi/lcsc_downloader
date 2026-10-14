using CommunityToolkit.Mvvm.ComponentModel;
using ModelDownloader.Models;

namespace ModelDownloader.ViewModels;

public partial class ResultItemViewModel : ObservableObject
{
    public ResultItem Model { get; }

    [ObservableProperty]
    public partial bool IsChecked { get; set; } = false;

    /// <summary>立创元件编号(Supplier Part,缺失时回退 ProductCode)。</summary>
    public string? PartNumber =>
        Model.Attributes?.TryGetValue("Supplier Part", out var p) == true && !string.IsNullOrEmpty(p)
            ? p
            : Model.ProductCode;

    /// <summary>商城库存(异步填充;接口未提供时显示 —)</summary>
    [ObservableProperty]
    public partial string Stock { get; set; } = "—";

    /// <summary>商城单价(异步填充;接口未提供时显示 —)</summary>
    [ObservableProperty]
    public partial string Price { get; set; } = "—";

    public ResultItemViewModel(ResultItem model)
    {
        Model = model;
    }
}
