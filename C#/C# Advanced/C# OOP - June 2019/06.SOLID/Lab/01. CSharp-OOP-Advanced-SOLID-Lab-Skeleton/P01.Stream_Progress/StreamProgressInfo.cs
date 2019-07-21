namespace P01.Stream_Progress
{
    public class StreamProgressInfo 
    {
        private IResult result;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IResult item)
        {
            this.result = item;
        }

        public int CalculateCurrentPercent()
        {
            return (this.result.BytesSent * 100) / this.result.Length;
        }
    }
}
