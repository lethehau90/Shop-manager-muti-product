var MasOffer_urk = {
	can_run : function () {
		var rtg = this.get_rtg();
		if (rtg != 'urk') {
			return false;
		}
		return true;
	},
	get_param : function (name,url) {
		if (!url) url = location.href;
		name = name.replace(/[\[]/,"\\\[").replace(/[\]]/,"\\\]");
		var regexS = "[\\?&]"+name+"=([^&#]*)";
		var regex = new RegExp(regexS);
		var results = regex.exec(url);
		return results == null?null:results[1];
	},
	write_cookie : function (n, v, e) {
		var d = new Date();
		d.setTime(d.getTime() + (e*24*60*60*1000));
		var ee = "expires=" + d.toUTCString();
		document.cookie = n + "=" + v + "; " + ee + "; path=/";
	},
	get_cookie: function (cname) {
		var name = cname + "=";
		var ca = document.cookie.split(';');
		for (var i = 0; i < ca.length; i++) {
			var c = ca[i];
			while (c.charAt(0) == ' ') c = c.substring(1);
			if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
		}
		return undefined;
	},
	tracking_traffic : function () {
		var rtg = this.get_param('rtg');

		if (rtg == 'urk') {
			this.write_cookie('mo_rtg', 'urk', 30);
		}
	},
	get_rtg: function () {
		return this.get_cookie('mo_rtg');
	}
};

try {
	MasOffer_urk.tracking_traffic();
} catch (err){}

try {
	setTimeout(function() {
		if (MasOffer_urk.can_run()) {
			//ureka
			var $domain=window.location.host; (function(){var media_url=location.protocol+'//jsons.urekamedia.com/getdata.js?id='+$domain;var media_script=document.createElement('script');media_script.type='text/javascript';media_script.onload=function(){if(typeof $call==='function'){$call()}};media_script.src=media_url;media_script.async=true;if(document.getElementsByTagName("head").length>0)document.getElementsByTagName("head")[0].appendChild(media_script);else if(document.getElementsByTagName("body").length>0)document.getElementsByTagName("body")[0].appendChild(media_script)})();
			// /ureka
		}
	}, 200);
} catch (err) {}



