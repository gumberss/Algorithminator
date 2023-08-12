
//source: https://stackoverflow.com/questions/7616461/generate-a-hash-from-string-in-javascript
function hashCode(data: string) {
    var hash = 0,
        i, chr;
    if (data.length === 0) return hash;
    for (i = 0; i < data.length; i++) {
        chr = data.charCodeAt(i);
        hash = ((hash << 5) - hash) + chr;
        hash |= 0; // Convert to 32bit integer
    }
    return Math.abs(hash);
}


class Data {
    hashKey: number

    constructor(public id: string) {
        this.hashKey = hashCode(id);
    }
}

class Server {
    hashKey: number
    data: Data[]
    constructor(public name: string) {
        this.hashKey = hashCode(name);
        this.data = []
    }

    requestData(dataKey: string): Data | undefined {
        console.log(`${dataKey} Requested to the server ${this.name}`)
        const data = this.data.find(x => x.id == dataKey)
        console.log(data)
        console.log(`${dataKey} Found? ${data != undefined}`)
        return data
    }
    addData(data: Data) {
        this.data.push(data);

        console.log(`${data.id} Added to the server ${this.name}`)
    }
}

class RingMap {
    constructor(public serverRingId: number, public server: Server) { }
}

class Ring {
    ring: RingMap[]

    constructor(public size: number, public servers: Array<Server>) {
        this.ring = servers
            .map(s => new RingMap(s.hashKey % size, s))
            .sort((a, b) => a.serverRingId - b.serverRingId)
        console.log(this.ring.map(x => x.serverRingId))
    }

    findServer(dataKey: string): Server | undefined {
        const hashdataRingKey = hashCode(dataKey) % this.size;

        const server = this.ring
            .find(s => s.serverRingId > hashdataRingKey)
            ?.server
        console.log(`first server found?: ${server != undefined}`)
        return server || this.ring[0].server
    }

    getData(dataKey: string): Data | undefined {
        return this.findServer(dataKey)
            ?.requestData(dataKey)
    }
    addData(data: Data) {
        return this.findServer(data.id)
            ?.addData(data)
    }
}

function test() {
    const ringSize = 1000
    const servers = [
        new Server("1 Server"),
        new Server("2 Server"),
        new Server("3 Server"),
        new Server("4 Server"),
        new Server("5 Server")
    ]
    const ring = new Ring(ringSize, servers)
    ring.addData(new Data("1 Data 1"))
    ring.addData(new Data("234234234"))
    ring.addData(new Data("56456456"))
    ring.addData(new Data("678976976"))
    ring.addData(new Data("112312 Data 143543543"))

    const data1 = ring.getData("1 Data 1")

    console.log(data1)
}

export {
    test
}