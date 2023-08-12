"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.test = void 0;
//source: https://stackoverflow.com/questions/7616461/generate-a-hash-from-string-in-javascript
function hashCode(data) {
    var hash = 0, i, chr;
    if (data.length === 0)
        return hash;
    for (i = 0; i < data.length; i++) {
        chr = data.charCodeAt(i);
        hash = ((hash << 5) - hash) + chr;
        hash |= 0; // Convert to 32bit integer
    }
    return Math.abs(hash);
}
class Data {
    constructor(id) {
        this.id = id;
        this.hashKey = hashCode(id);
    }
}
class Server {
    constructor(name) {
        this.name = name;
        this.hashKey = hashCode(name);
        this.data = [];
    }
    requestData(dataKey) {
        console.log(`${dataKey} Requested to the server ${this.name}`);
        const data = this.data.find(x => x.id == dataKey);
        console.log(data);
        console.log(`${dataKey} Found? ${data != undefined}`);
        return data;
    }
    addData(data) {
        this.data.push(data);
        console.log(`${data.id} Added to the server ${this.name}`);
    }
}
class RingMap {
    constructor(serverRingId, server) {
        this.serverRingId = serverRingId;
        this.server = server;
    }
}
class Ring {
    constructor(size, servers) {
        this.size = size;
        this.servers = servers;
        this.ring = servers
            .map(s => new RingMap(s.hashKey % size, s))
            .sort((a, b) => a.serverRingId - b.serverRingId);
        console.log(this.ring.map(x => x.serverRingId));
    }
    findServer(dataKey) {
        var _a;
        const hashdataRingKey = hashCode(dataKey) % this.size;
        const server = (_a = this.ring
            .find(s => s.serverRingId > hashdataRingKey)) === null || _a === void 0 ? void 0 : _a.server;
        console.log(`first server found?: ${server != undefined}`);
        return server || this.ring[0].server;
    }
    getData(dataKey) {
        var _a;
        return (_a = this.findServer(dataKey)) === null || _a === void 0 ? void 0 : _a.requestData(dataKey);
    }
    addData(data) {
        var _a;
        return (_a = this.findServer(data.id)) === null || _a === void 0 ? void 0 : _a.addData(data);
    }
}
function test() {
    const ringSize = 1000;
    const servers = [
        new Server("1 Server"),
        new Server("2 Server"),
        new Server("3 Server"),
        new Server("4 Server"),
        new Server("5 Server")
    ];
    const ring = new Ring(ringSize, servers);
    ring.addData(new Data("1 Data 1"));
    ring.addData(new Data("234234234"));
    ring.addData(new Data("56456456"));
    ring.addData(new Data("678976976"));
    ring.addData(new Data("112312 Data 143543543"));
    const data1 = ring.getData("1 Data 1");
    console.log(data1);
}
exports.test = test;
//# sourceMappingURL=hashing.js.map