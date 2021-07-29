using ModelLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinancialControl.ViewModels
{
    public class CategoriesListViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        Category _selectedCategory;
        public Category SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }

            set
            {
                _selectedCategory = value;
                Notify("SelectedCategory");

            }
        }

        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories { get { return categories; } set { categories = value; Notify(); } }

        public CategoriesListViewModel()
        {
            //CreateCategoryCommand = new Command(CreateCategoryCmd);
            //UpdateCategoryCommand = new Command(UpdateCategoryCmd);

            Categories = new ObservableCollection<Category>()
            {
                new Category(){ Id=0,Name="teste a"},
                new Category(){ Id=1,Name="teste b"},
                new Category(){ Id=2,Name="teste c"},
                new Category(){ Id=3,Name="teste d"},
            };
        }

        public ICommand CreateCategoryCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    string result = await Application.Current.MainPage.DisplayPromptAsync("Cadastrar categoria", "Nome da categoria:");
                    if (!string.IsNullOrEmpty(result))
                    {
                        //create a new category
                        categories.Add(new Category() { Id = categories.Last().Id++, Name = result });
                    }
                });
            }
        }

        public ICommand UpdateCategoryCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    Category category = (e as Category);
                    string result = await Application.Current.MainPage.DisplayPromptAsync("Editar categoria", "Nome da categoria:", initialValue: category.Name);
                    if (!string.IsNullOrEmpty(result))
                    {
                        //update this category from list
                        categories[categories.IndexOf(categories.FirstOrDefault(x => x.Id == category.Id))] = new Category() { Name = result };
                    }
                });
            }
        }

        public ICommand DeleteCategoryCommand
        {
            get
            {
                return new Command(async (e) =>
                {
                    Category category = (e as Category);
                    if (await Application.Current.MainPage.DisplayAlert("Excluir categoria?", category.Name, "Excluir", "Cancelar"))
                    {
                        //remove this category from list
                        if (categories.Remove(categories[categories.IndexOf(categories.FirstOrDefault(x => x.Id == category.Id))]))
                        {
                            await Application.Current.MainPage.DisplayAlert("Confirmação", "Categoria Excluida", null, "Continuar");
                        }
                    }
                });
            }
        }
    }
}
