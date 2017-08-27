package Lesson1;

/**
 * Created by Looky on 03.07.2017.
 */
public class Queue {
    private int[] storage;
    private int tailIndex;
    private int headIndex;


    public Queue(int capacity) {
        storage = new int[capacity];
    }

    public void enqueue(int item) {
        if (tailIndex + 1 == headIndex || (tailIndex == storage.length - 1 && headIndex == 0)) {
            throw new IndexOutOfBoundsException();
        } else {
            storage[tailIndex] = item;
            if (tailIndex == storage.length - 1) {
                tailIndex = 0;
            } else {
                tailIndex++;
            }
        }
    }

    public int dequeue()
    {
        if (tailIndex == headIndex) {
            throw new ArrayStoreException("Очередь пуста");
        }
        else {
            int result = storage[headIndex];
            if (headIndex == storage.length-1)
            {
                headIndex = 0;
            }
            else {
                headIndex++;
            }
            return result;
        }
    }
}

