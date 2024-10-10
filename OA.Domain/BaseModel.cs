namespace OA.Domain
{
    public class BaseModel<T>
    {
        public T? Id { get; set; }
        public DateTime DateCreated { get; set; }

        public BaseModel()
        {
            DateCreated = DateTime.Now;
        }
    }
}
