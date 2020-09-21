using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Helpers
{
    public class Images
    {
        public List<string> ImageList { get; set; } = new List<string>();
        public Images()
        {
            ImageList.Add("analytics-graph-bar.svg");
            ImageList.Add("baby-trolley.svg");
            ImageList.Add("baggage.svg");
            ImageList.Add("beach-parasol-water-1.svg");
            ImageList.Add("biking-person.svg");
            ImageList.Add("bin-2.svg");
            ImageList.Add("binocular.svg");
            ImageList.Add("bomb-grenade.svg");
            ImageList.Add("building-modern-1.svg");
            ImageList.Add("camera-flash.svg");
            ImageList.Add("coffee-cold.svg");
            ImageList.Add("coffee-machine.svg");
            ImageList.Add("cog.svg");
            ImageList.Add("content-ink-pen-write.svg");
            ImageList.Add("content-pen-3.svg");
            ImageList.Add("content-typing-machine.svg");
            ImageList.Add("couple-man-woman.svg");
            ImageList.Add("coupon-cut.svg");
            ImageList.Add("crypto-currency-bitcoin-imac.svg");
            ImageList.Add("dating-rose.svg");
            ImageList.Add("dating-smartphone-man.svg");
            ImageList.Add("design-tool-pen-station.svg");
            ImageList.Add("design-tool-quill-2.svg");
            ImageList.Add("desktop-monitor-download.svg");
            ImageList.Add("desktop-monitor-upload.svg");
            ImageList.Add("diet-waist-1.svg");
            ImageList.Add("e-learning-monitor.svg");
            ImageList.Add("email-action-receive.svg");
            ImageList.Add("filter-picture.svg");
            ImageList.Add("flag.svg");
            ImageList.Add("footwear-heels-ankle.svg");
            ImageList.Add("gauge-dashboard-1.svg");
            ImageList.Add("golf-hole.svg");
            ImageList.Add("graph-stats-circle.svg");
            ImageList.Add("hammer-1.svg");
            ImageList.Add("headphones-human.svg");
            ImageList.Add("human-resources-search-employees.svg");
            ImageList.Add("insurance-card.svg");
            ImageList.Add("lab-flask-experiment.svg");
            ImageList.Add("landmark-japan-shrine.svg");
            ImageList.Add("laptop-smiley-1.svg");
            ImageList.Add("lighter.svg");
            ImageList.Add("like-1.svg");
            ImageList.Add("login-2.svg");
            ImageList.Add("love-boat.svg");
            ImageList.Add("maps-pin.svg");
            ImageList.Add("medical-personnel-doctor.svg");
            ImageList.Add("megaphone-1.svg");
            ImageList.Add("messages-people-person-bubble-oval.svg");
            ImageList.Add("mobile-phone-2.svg");
            ImageList.Add("modern-tv-3d-glasses.svg");
            ImageList.Add("money-wallet-open.svg");
            ImageList.Add("monkey.svg");
            ImageList.Add("mood-happy.svg");
            ImageList.Add("mouse.svg");
            ImageList.Add("nautic-sports-sailing-person.svg");
            ImageList.Add("office-work-wireless.svg");
            ImageList.Add("optimization-timer-1.svg");
            ImageList.Add("outdoors-tree-valley.svg");
            ImageList.Add("pencil-2.svg");
            ImageList.Add("people-man-graduate.svg");
            ImageList.Add("people-woman-glasses-1.svg");
            ImageList.Add("phone-actions-ring.svg");
            ImageList.Add("pin-monitor.svg");
            ImageList.Add("pin.svg");
            ImageList.Add("plane-trip-international.svg");
            ImageList.Add("presentation-board-graph.svg");
            ImageList.Add("print-text.svg");
            ImageList.Add("programming-flag.svg");
            ImageList.Add("rat.svg");
            ImageList.Add("rooster.svg");
            ImageList.Add("science-dna.svg");
            ImageList.Add("screen-1.svg");
            ImageList.Add("send-email-2.svg");
            ImageList.Add("shipment-upload.svg");
            ImageList.Add("shop-cashier-man.svg");
            ImageList.Add("shop-cashier-woman.svg");
            ImageList.Add("shopping-bag-heart.svg");
            ImageList.Add("shopping-bag-tag-1.svg");
            ImageList.Add("shopping-cart-download.svg");
            ImageList.Add("show-hat-magician-1.svg");
            ImageList.Add("skull-1.svg");
            ImageList.Add("skunk.svg");
            ImageList.Add("stamps-famous.svg");
            ImageList.Add("tablet-touch.svg");
            ImageList.Add("taking-pictures-circle.svg");
            ImageList.Add("target-center-2.svg");
            ImageList.Add("video-game-gamasutra.svg");
            ImageList.Add("video-game-mario-3.svg");
            ImageList.Add("video-game-mario-enemy.svg");
            ImageList.Add("video-player-1.svg");
            ImageList.Add("video-player-cloud.svg");
            ImageList.Add("video-player-monitor.svg");
            ImageList.Add("view-off.svg");
            ImageList.Add("view.svg");
            ImageList.Add("warehouse-cart-packages.svg");
            ImageList.Add("warehouse-storage-3.svg");
            ImageList.Add("wench-double.svg");
            ImageList.Add("whale-body.svg");
            ImageList.Add("wireless-payment-credit-card-dollar.svg");
        }
        public string ReturnRandomImage()
        {
            var random = new Random();
            var imagesListCount = ImageList.Count;
            var imageListIndex = random.Next(0, imagesListCount);
            var image = ImageList[imageListIndex];
            return image;
        }
    }
}
