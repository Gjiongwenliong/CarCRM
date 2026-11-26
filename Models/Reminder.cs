using CarCRM.Data;
using CarCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CarCRM.Models;

public class Reminder
{
    public int Id { get; set; }
    public Car? Car { get; set; } // Navigation property for the related Car

    public int CarId { get; set; }

    public DateTime ReminderDate { get; set; }

    public string ServiceItem { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public static Reminder CreateRecord(CarCRMContext context, Reminder reminder)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(reminder);

        context.Reminders.Add(reminder);
        context.SaveChanges();
        return reminder;
    }

    public static Reminder ReadRecord(CarCRMContext context, int id)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.Reminders
            .Include(r => r.Car)
            .FirstOrDefault(r => r.Id == id)
            ?? throw new InvalidOperationException($"Reminder with id {id} was not found.");
    }

    public static Reminder UpdateRecord(CarCRMContext context, Reminder reminder)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(reminder);

        var existingReminder = context.Reminders.FirstOrDefault(r => r.Id == reminder.Id)
            ?? throw new InvalidOperationException($"Reminder with id {reminder.Id} was not found.");

        existingReminder.CarId = reminder.CarId;
        existingReminder.ReminderDate = reminder.ReminderDate;
        existingReminder.ServiceItem = reminder.ServiceItem;
        existingReminder.Status = reminder.Status;
        existingReminder.Notes = reminder.Notes;

        context.SaveChanges();
        return existingReminder;
    }

    public static void DeleteRecord(CarCRMContext context, int id)
    {
        ArgumentNullException.ThrowIfNull(context);

        var reminder = context.Reminders.FirstOrDefault(r => r.Id == id)
            ?? throw new InvalidOperationException($"Reminder with id {id} was not found.");

        context.Reminders.Remove(reminder);
        context.SaveChanges();
    }

    public static List<Reminder> Index(CarCRMContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.Reminders
            .Include(r => r.Car)
            .OrderBy(r => r.ReminderDate)
            .ToList();
    }
}