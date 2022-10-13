using System;
int[] lista = new int[]
{1, 3, 5, 7, 2, 4, 16, 32};

mergesort(lista);

foreach (var n in lista){
    Console.Write($"{n}, ");
}


void mergesort(int[] arr){
    int e = arr.Length;
    int[] arraux = new int[e];
    mergesortrec(arr, arraux, 0, e);
}

void mergesortrec(
    int[] arr, 
    int[] arraux,
    int s, int e){
    if (e - s < 2)
        return;
    int p = (s + e) / 2;

    mergesortrec(arr, arraux, s, p);
    mergesortrec(arr, arraux, p, e);
    merge(arr, arraux, s, p, e);
}

void merge(int[] arr, int[] arraux, int s, int p, int e){
    int i = s, j = p, k = s;
    while(i < p && j < e){
        if(arr[i] < arr[j]){
            arraux[k] = arr[i];
            i++;
            k++;
        }
        else{
            arraux[k] = arr[j];
            j++;
            k++;
        }
    }

    while(i < p){
        arraux[k] = arr[i];
        i++;
        k++;
    }
    
    while(j < p){
        arraux[k] = arr[j];
        j++;
        k++;
    }

    for(int t = s; t < e; t++){
        arr[t] = arraux[t];
    }
}
// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// int num = unchecked(20000000 + 3000000);

// char
// string
// bool
// float
// dowble 
// Epsilon
// ulong
// uint
// ushort
// sbyte
// object
// decimal
// MinValue
// MaxValue
// byte
// dynamic
// var
// int[] arr = new int[10];
// arr[0] = 4
// arr[^1] = 4
// var arr = arr[0..2]
// operadores
// ^ & | >> << % 
// int? y = null;

// if(y.HasValue){
//     Console.WriteLine(y.Value);
//     Console.WriteLine(y ?? 7);
//     Console.WriteLine(y.ToString());
// }

// string s3 = null;
// string s4 = s3?.Replace('a', 'b') ?? "Erro";
// Console.WriteLine(s4);