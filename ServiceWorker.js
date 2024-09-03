const cacheName = "DefaultCompany-Test Avi-1.0";
const contentToCache = [
    "Build/868ad3e5f43e7a2d53d450d58e45443c.loader.js",
    "Build/cd87acfcccf0f23d88d1be77c3161441.framework.js.gz",
    "Build/ede021e813e169b264338ae4abee50c6.data.gz",
    "Build/fdbe0027d0b81565558683c7350634bb.wasm.gz",
    "TemplateData/style.css"

];

self.addEventListener('install', function (e) {
    console.log('[Service Worker] Install');
    
    e.waitUntil((async function () {
      const cache = await caches.open(cacheName);
      console.log('[Service Worker] Caching all: app shell and content');
      await cache.addAll(contentToCache);
    })());
});

self.addEventListener('fetch', function (e) {
    e.respondWith((async function () {
      let response = await caches.match(e.request);
      console.log(`[Service Worker] Fetching resource: ${e.request.url}`);
      if (response) { return response; }

      response = await fetch(e.request);
      const cache = await caches.open(cacheName);
      console.log(`[Service Worker] Caching new resource: ${e.request.url}`);
      cache.put(e.request, response.clone());
      return response;
    })());
});
