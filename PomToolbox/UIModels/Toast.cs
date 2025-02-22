namespace PomToolbox.UIModels;

public class Toast
{
    public required string Message { get; set; }
    public required ToastType Type { get; set; }
    public static int Duration { get; } = 3000;

    public string GetToastTypeClass() {
        switch (Type) {
            case ToastType.Success:
                return "alert-success";
            case ToastType.Error:
                return "alert-error";
            case ToastType.Warning:
                return "alert-warning";
            case ToastType.Info:
                return "alert-info";
            default:
                return "toast-info";
        }
    }

    public enum ToastType {
        Success,
        Error,
        Warning,
        Info,
    }
}


