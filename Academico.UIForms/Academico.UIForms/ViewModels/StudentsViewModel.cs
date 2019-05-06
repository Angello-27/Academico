namespace Academico.UIForms.ViewModels
{
    using Common.Models;
    using Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class StudentsViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Student> students;
        private bool isRefreshing;

        public ObservableCollection<Student> Students
        {
            get => this.students;
            set => this.SetValue(ref this.students, value);
        }

        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }

        public StudentsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadStudents();
        }

        private async void LoadStudents()
        {
            this.IsRefreshing = true;
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetListAsync<Student>(
                url,
                "/api",
                "/Students",
                "bearer", 
                MainViewModel.GetInstance().Token.Token);

            this.IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var myStudents = (List<Student>)response.Result;
            this.Students = new ObservableCollection<Student>(myStudents);
        }
    }
}
