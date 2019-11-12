

$("#hlp-1").click(function(){ $("#hl-panel").slideToggle("slow"); $("#hl-panel2").slideUp(); });
$("#hlp-2").click(function(){ $("#hl-panel2").slideToggle("slow"); $("#hl-panel").slideUp(); });
$(".close-link").click(function(){ $("#hl-panel").slideUp(); $("#hl-panel2").slideUp(); });


$(".btn-login").click(function(){ $(".login-panel").toggle(); $(".signup-panel").hide();});
$(".login-panel-close").click(function(){ $(".login-panel").hide() });

$(".btn-signup").click(function(){ $(".signup-panel").toggle(); $(".login-panel").hide();});
$(".signup-panel-close").click(function(){ $(".signup-panel").hide();  });

$(".profil-menu h1").click(function(){ $(".profil-menu ul").slideToggle("slow");});

$("#gbol").click(function(){ $(".gbol").slideToggle("slow"); $(".csaat").slideUp(); });

$("#csaat").click(function(){ $(".csaat").slideToggle("slow"); $(".gbol").slideUp(); });
$(".gbol>span").click(function(){$(".gbol").slideUp(); });
$(".csaat>span").click(function(){$(".csaat").slideUp(); });

$("#odeme-kkart").click(function(){ $(".odeme-kkart").toggle("slow");});



$("[data-toggle=popover]").popover({
	trigger: "hover",
    html: true, 
	content: function() {
          return $('#popover-content').html();
        }
});

$(function () {
  $('[data-toggle="tooltip"]').tooltip()
})

jQuery(function () {
    jQuery('#profil-tab-header a:first').tab('show')
})

$("#adres-ayarlari").click(function(){ 
	var name=$(this).attr('name');
	$("#"+name).toggle("explode");
 });

 
 /**/
 $( ".modal" ).each(function(index) {
   $(this).on('show.bs.modal', function (e) {
 var open = $(this).attr('data-easein');
     if(open == 'shake') {
                 $('.modal-dialog').velocity('callout.' + open);
            } else if(open == 'pulse') {
                 $('.modal-dialog').velocity('callout.' + open);
            } else if(open == 'tada') {
                 $('.modal-dialog').velocity('callout.' + open);
            } else if(open == 'flash') {
                 $('.modal-dialog').velocity('callout.' + open);
            }  else if(open == 'bounce') {
                 $('.modal-dialog').velocity('callout.' + open);
            } else if(open == 'swing') {
                 $('.modal-dialog').velocity('callout.' + open);
            }else {
              $('.modal-dialog').velocity('transition.' + open);
            }
             
}); 
});
 /**/
 




$(window).scroll(function () {
        if ($(this).scrollTop() > 40 && $(window).width() > 768) {
            $("header").addClass("header-fixed");
            $("#content").addClass("content");
			 $("#top").fadeIn(500);
        }
		else if($(this).scrollTop() < 40 && $(window).width() > 768) {
            $("header").removeClass("header-fixed");
			$("#top").fadeOut(500);
			$("#col-left").removeClass("basket-fixed");
        }
		
		
		var hright=$(".col-right").height();
		var hleft=$("#col-left").height();
		var fark=hright - hleft;
	
        if ($(this).scrollTop() > (fark - 50)) {
			$("#col-left").removeClass("basket-fixed");
			$("#col-left").css({'margin-top':fark});
        }
		if ($(this).scrollTop() < fark && $(this).scrollTop() >50) {
			$("#col-left").addClass("basket-fixed");
			$("#col-left").css({'margin-top':'0px'});
			$("#content").removeClass("content");
        }
    });

	$("#top").click(function(){ 
        $("html, body").animate({ scrollTop: "0" }, 500);
       
    });
	
	
	
	