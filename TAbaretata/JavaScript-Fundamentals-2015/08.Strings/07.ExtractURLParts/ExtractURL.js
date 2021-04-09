/*
Problem 7: Write a script that parses an URL address given in the format:
[protocol]://[server]/[resource]
and extracts from it the [protocol], [server] and [resource] elements. Return the elements in a JSON object.
For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
{protocol: 'http', 
 server: 'www.devbg.org', 
 resource: '/forum/index.php'}
*/

function extractURLParts(url) {
    var startIndex = 0,
        endIndex = 0,
		protocolStr,
		serverStr,
		resourceStr;

    endIndex = url.indexOf(':');
    protocolStr = url.substring(0, endIndex);
    startIndex = endIndex + 3;

    endIndex = url.indexOf('/', startIndex);
    serverStr = url.substring(startIndex, endIndex);

    resourceStr = url.substr(endIndex + 1);

    return {
        protocol: protocolStr,
        server: serverStr,
        resource: resourceStr
    }
}

var url = 'http://www.devbg.org/forum/index.php';
console.log(extractURLParts(url));
