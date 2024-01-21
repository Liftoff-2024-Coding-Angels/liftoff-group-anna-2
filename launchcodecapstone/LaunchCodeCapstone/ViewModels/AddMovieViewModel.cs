using System;

public class Class1
{
	public Class1()
	{

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title needs to be less than 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; } //personally set date format of MM / DD / YYYY

        [Required(ErrorMessage = "Please make a selection.")]
        public bool HaveWatched { get; set; }


        public List<int> Rating { get; set; }
}
}
