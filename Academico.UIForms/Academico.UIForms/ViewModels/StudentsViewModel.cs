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

        public ObservableCollection<Student> Students
        {
            get => this.students;
            set => this.SetValue(ref this.students, value);
        }

        public StudentsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadStudents();
        }

        private async void LoadStudents()
        {
            var response = await this.apiService.GetListAsync<Student>(
                "https://academicotopicos.azurewebsites.net",
                "/api",
                "/Students");
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
