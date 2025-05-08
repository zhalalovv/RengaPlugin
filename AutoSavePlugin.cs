using System;
using System.Timers;
using System.Windows.Forms;
using Renga;

namespace AutoSaveRengaPlugin
{
    public class AutoSavePlugin
    {
        private Renga.Application _rengaApp;
        private System.Timers.Timer _checkProjectTimer;
        private System.Timers.Timer _autoSaveTimer;
        private bool _autoSaveStarted = false;

        public void Init(Renga.Application app)
        {
            _rengaApp = app;

            _checkProjectTimer = new System.Timers.Timer(3000); // Проверяем каждые 3 секунды
            _checkProjectTimer.Elapsed += CheckProjectOpened;
            _checkProjectTimer.Start();

            MessageBox.Show("Плагин автосохранения запущен. Ожидание открытия проекта...");
        }

        public void Stop()
        {
            _checkProjectTimer?.Stop();
            _checkProjectTimer?.Dispose();

            _autoSaveTimer?.Stop();
            _autoSaveTimer?.Dispose();
        }

        private void CheckProjectOpened(object sender, ElapsedEventArgs e)
        {
            if (!_autoSaveStarted && _rengaApp.Project != null)
            {
                _autoSaveStarted = true;
                _checkProjectTimer.Stop();
                StartAutoSave();
            }
        }

        private void StartAutoSave()
        {
            _autoSaveTimer = new System.Timers.Timer(5 * 60 * 1000); // каждые 5 минут
            _autoSaveTimer.Elapsed += OnAutoSave;
            _autoSaveTimer.Start();

            MessageBox.Show("Автосохранение включено (каждые 5 минут).");
        }

        private void OnAutoSave(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (_rengaApp.Project != null)
                {
                    _rengaApp.Project.Save(); // сохраняем без изменения пути
                    Console.WriteLine("Автосохранение выполнено.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при автосохранении: {ex.Message}");
            }
        }
    }
}
