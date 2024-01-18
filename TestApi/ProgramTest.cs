using HashidsNet;

var hashIds = new Hashids("tomas", 11);

string hashID = hashIds.Encode(5);
Console.WriteLine(hashID);
//7-"KAMgqkJmzQv"
//5"XEvo4gxmr2d"